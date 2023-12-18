using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFcoreEg.Models;

public partial class Usertbl
{
    [Required(ErrorMessage ="Email is Mandatory")]
    [DataType(DataType.EmailAddress,ErrorMessage ="Email Id is not valid")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage ="Password is Mandatory")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Compare("Password",ErrorMessage ="Passwords do not match")]
    [NotMapped]
    public string ConfirmPassword { get; set; }

    public string? Username { get; set; }
}
