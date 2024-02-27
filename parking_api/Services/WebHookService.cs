using Microsoft.EntityFrameworkCore;
using parking_api.Data;
using parking_api.Models.EFModels;
using parking_api.Models;

namespace parking_api.Services;
/// <summary>
/// Represents a service for handling web hooks.
/// </summary>
public interface IWebHookService
{
    /// <summary>
    /// Handles the camera log.
    /// </summary>
    /// <param name="log">The camera log.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task HandleCameraLog(RootALpr log, CancellationToken cancellationToken);
}

/// <summary>
/// Represents a service for handling web hooks.
/// </summary>
public class WebHookService : IWebHookService
{
    private readonly AppDbContext _AppDbContext;
    private readonly IConfiguration _Configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="WebHookService"/> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    /// <param name="configuration">The configuration.</param>
    public WebHookService(AppDbContext context, IConfiguration configuration)
    {
        this._AppDbContext = context;
        this._Configuration = configuration;
    }

    /// <inheritdoc/>
    public async Task HandleCameraLog(RootALpr log, CancellationToken cancellationToken)
    {

        TransformedWebHook transformedWebHook = new()
        {
            DataSourceId = log.Camera_id.ToString(),
            CapturedOn = DateTimeOffset.FromUnixTimeMilliseconds(log.Epoch_start ?? 0).DateTime,
            PlateNo = log.Best_plate?.Plate?.ToLower(),
            Color = log.Vehicle?.Color?.FirstOrDefault()?.Name,
            Make = log.Vehicle?.Make?.FirstOrDefault()?.Name,
            Model = log.Vehicle?.Make_model?.FirstOrDefault()?.Name,
            Type = log.Vehicle?.Body_type?.FirstOrDefault()?.Name,
            Year = log.Vehicle?.Year?.FirstOrDefault()?.Name,
            VehiclePic = Convert.FromBase64String(log.Vehicle_crop_jpeg),
            PlatePic = Convert.FromBase64String(log.Best_plate?.Plate_crop_jpeg),
            Direction = log.Direction_of_travel_id == 0 ? "In" : log.Direction_of_travel_id == 1 ? "Out" : log.Travel_direction.ToString()
        };

        // get AllowedCar
        var allowedCar = await _AppDbContext.Units
        .Join(_AppDbContext.Lots, unit => unit.CondoId, lot => lot.CondoId, (unit, lot) => new { Unit = unit, Lot = lot })
            .Join(_AppDbContext.Cameras, ul => ul.Lot.Id, camera => camera.LotId, (ul, camera) => new { ul.Unit, ul.Lot, Camera = camera })
            .Join(_AppDbContext.Cars, ulc => ulc.Unit.Id, car => car.UnitId, (ulc, car) => new { ulc.Unit, ulc.Lot, ulc.Camera, Car = car })
            .Where(ulcu => ulcu.Camera.DataSourceId == transformedWebHook.DataSourceId && ulcu.Car.PlateNo == transformedWebHook.PlateNo)
            .Select(ulcu => ulcu.Car)
            .FirstOrDefaultAsync<Car>(cancellationToken);

        if (allowedCar != null)
        {
            if (allowedCar.ImgPath == null)
            {
                var filePath = await SaveFileToFolder(transformedWebHook.VehiclePic, cancellationToken);
                allowedCar.ImgPath = filePath;
                _AppDbContext.Cars.Update(allowedCar);
                await _AppDbContext.SaveChangesAsync(cancellationToken);

            }
            transformedWebHook.Archived = true;
        }

        var existingCarInLogs = await _AppDbContext.CamLogs
            .Where(l => l.PlateNo == transformedWebHook.PlateNo && l.ResolvedStatus == false && l.Archived == false)
            .FirstOrDefaultAsync<CamLog>(cancellationToken);

        if (existingCarInLogs != null)
        {
            if (existingCarInLogs.Direction == "In")
            {
                _AppDbContext.CamLogs.Remove(existingCarInLogs);
                await _AppDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            else if (existingCarInLogs.Direction == "Out")
            {
                transformedWebHook.Archived = true;

            }
            else
            {
                throw new Exception("didn't enter when out or no direction specified");
            }
        }

        transformedWebHook.CarImgPath = await SaveFileToFolder(transformedWebHook.VehiclePic, cancellationToken);
        transformedWebHook.PlateImgPath = await SaveFileToFolder(transformedWebHook.PlatePic, cancellationToken);
        await SaveLogRecord(transformedWebHook, cancellationToken);

    }

    private async Task<string> SaveFileToFolder(byte[] fileData, CancellationToken cancellationToken)
    {
        var fileName = Guid.NewGuid().ToString() + ".jpg";

        var folderPath = _Configuration.GetSection("FileSection")["BasePath"];

        var filePath = Path.Combine(folderPath, fileName);

        Directory.CreateDirectory(folderPath);

        await File.WriteAllBytesAsync(filePath, fileData, cancellationToken);

        return fileName;
    }

    private async Task<CamLog> SaveLogRecord(TransformedWebHook transformedWebHook, CancellationToken cancellationToken)
    {
        CamLog camLog = new()
        {
            DataSourceId = transformedWebHook.DataSourceId,
            PlateNo = transformedWebHook.PlateNo,
            CapturedOn = transformedWebHook.CapturedOn ?? DateTime.Now,
            Make = transformedWebHook.Make,
            Model = transformedWebHook.Model,
            Color = transformedWebHook.Color,
            Year = transformedWebHook.Year,
            Type = transformedWebHook.Type,
            Direction = transformedWebHook.Direction,
            PlateImgPath = transformedWebHook.PlateImgPath,
            CarImgPath = transformedWebHook.CarImgPath,
            Archived = transformedWebHook.Archived ?? false,

        };

        await _AppDbContext.CamLogs.AddAsync(camLog, cancellationToken);
        await _AppDbContext.SaveChangesAsync(cancellationToken);
        return camLog;

    }
}

