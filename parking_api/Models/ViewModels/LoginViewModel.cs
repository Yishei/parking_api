﻿using System.ComponentModel.DataAnnotations;

namespace parking_api.Models.ViewModels;

public class LoginViewModel
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
    public string Username { get; set; }
    public string ClientVersion {  get; set; }
}
