namespace parking_api.Models;

public class BestPlate
{
    public string? Plate { get; set; }
    public double? Confidence { get; set; }
    public int? Matches_template { get; set; }
    public int? Plate_index { get; set; }
    public string? Region { get; set; }
    public int? Region_confidence { get; set; }
    public double? Processing_time_ms { get; set; }
    public int? Requested_topn { get; set; }
    public List<Coordinate>? Coordinates { get; set; }
    public string? Plate_crop_jpeg { get; set; }
    public VehicleRegion? Vehicle_region { get; set; }
    public bool? Vehicle_detected { get; set; }
    public List<Candidate>? Candidates { get; set; }
}

public class BodyType
{
    public string? Name { get; set; }
    public double? Confidence { get; set; }
}

public class Candidate
{
    public string? Plate { get; set; }
    public double? Confidence { get; set; }
    public int? Matches_template { get; set; }
}

public class Color
{
    public string? Name { get; set; }
    public double? Confidence { get; set; }
}

public class Coordinate
{
    public int? X { get; set; }
    public int? Y { get; set; }
}

public class IsVehicle
{
    public string? Name { get; set; }
    public double? Confidence { get; set; }
}

public class Make
{
    public string? Name { get; set; }
    public double? Confidence { get; set; }
}

public class MakeModel
{
    public string? Name { get; set; }
    public double? Confidence { get; set; }
}

public class MissingPlate
{
    public string? Name { get; set; }
    public double? Confidence { get; set; }
}

public class Orientation
{
    public string? Name { get; set; }
    public double? Confidence { get; set; }
}

public class PlatePath
{
    public int? X { get; set; }
    public int? Y { get; set; }
    public int? W { get; set; }
    public int? H { get; set; }
    public int? T { get; set; }
    public int? F { get; set; }
}

public class RootALpr
{
    public string? Data_type { get; set; }
    public int? Version { get; set; }
    public long? Epoch_start { get; set; }
    public long? Epoch_end { get; set; }
    public int? Frame_start { get; set; }
    public int? Frame_end { get; set; }
    public string? Company_id { get; set; }
    public string? Agent_uid { get; set; }
    public string? Agent_version { get; set; }
    public string? Agent_type { get; set; }
    public int? Camera_id { get; set; }
    public double? Gps_longitude { get; set; }
    public string? Country { get; set; }
    public List<string?>? Uuids { get; set; }
    public List<VehiclePath>? Vehicle_path { get; set; }
    public List<int?>? Plate_indexes { get; set; }
    public List<Candidate>? Candidates { get; set; }
    public BestPlate? Best_plate { get; set; }
    public double? Best_confidence { get; set; }
    public string? Best_plate_number { get; set; }
    public string? Best_region { get; set; }
    public double? Best_region_confidence { get; set; }
    public bool? Matches_template { get; set; }
    public List<PlatePath>? Plate_path { get; set; }
    public string? Vehicle_crop_jpeg { get; set; }
    public string? Overview_jpeg { get; set; }
    public string? Best_uuid { get; set; }
    public long? Best_uuid_epoch_ms { get; set; }
    public int? Best_image_width { get; set; }
    public int? Best_image_height { get; set; }
    public double? Travel_direction { get; set; }
    public bool? Is_parked { get; set; }
    public bool? Is_preview { get; set; }
    public string? Vehicle_signature { get; set; }
    public Vehicle? Vehicle { get; set; }
    public WebServerConfig? Web_server_config { get; set; }
    public int? Direction_of_travel_id { get; set; }
    public string? Custom_data { get; set; }
}

public class Vehicle
{
    public List<Color>? Color { get; set; }
    public List<Make>? Make { get; set; }
    public List<MakeModel>? Make_model { get; set; }
    public List<BodyType>? Body_type { get; set; }
    public List<Year>? Year { get; set; }
    public List<Orientation>? Orientation { get; set; }
    public List<MissingPlate>? Missing_plate { get; set; }
    public List<IsVehicle>? Is_vehicle { get; set; }
}

public class VehiclePath
{
    public int? X { get; set; }
    public int? Y { get; set; }
    public int? W { get; set; }
    public int? H { get; set; }
    public int? T { get; set; }
    public int? F { get; set; }
}

public class VehicleRegion
{
    public int? X { get; set; }
    public int? Y { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
}

public class WebServerConfig
{
    public string? Camera_label { get; set; }
    public string? Agent_label { get; set; }
}

public class Year
{
    public string? Name { get; set; }
    public double? Confidence { get; set; }
}

