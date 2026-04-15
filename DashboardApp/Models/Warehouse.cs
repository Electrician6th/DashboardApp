using System;
using System.Collections.Generic;

namespace DashboardApp.Models;

public partial class Warehouse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool IsWorking { get; set; }

    public virtual ICollection<Fridge> Fridges { get; set; } = new List<Fridge>();
}
