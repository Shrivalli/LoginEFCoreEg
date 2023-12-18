using System;
using System.Collections.Generic;

namespace EFcoreEg.Models;

public partial class Department
{
    public int Did { get; set; }

    public string? Dname { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
