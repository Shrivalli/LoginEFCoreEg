using System;
using System.Collections.Generic;

namespace EFcoreEg.Models;

public partial class Student
{
    public int Sid { get; set; }

    public string Sname { get; set; } = null!;

    public double? Marks { get; set; }

    public DateTime? Doj { get; set; }

    public string? Email { get; set; }

    public string? Subject { get; set; }
}
