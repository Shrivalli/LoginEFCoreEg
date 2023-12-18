using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFcoreEg.Models;

public partial class Employee
{
    public int Eid { get; set; }

    [Required(ErrorMessage = "Ename is Mandatory")]
    [Display(Name = "Employee Name")]
    public string? Ename { get; set; }

    [Range(1000, 50000, ErrorMessage = "Salary should be between 1000 and 50000")]
    public double Salary { get; set; }

    [Display(Name = "Date of Joining")]
    [DataType(DataType.Date)]
    public DateTime? Doj { get; set; }

    public string? City { get; set; }

    public bool? Etype { get; set; }

    public int? Deptid { get; set; }

    public virtual Department? Dept { get; set; } //navigation property - foreign key
}
