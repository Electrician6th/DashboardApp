using System;
using System.Collections.Generic;

namespace DashboardApp.Models;

public partial class Fridge
{
    public int Id { get; set; }

    public int WarehouseId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int MinTemperature { get; set; }

    public int MaxTemperature { get; set; }

    public decimal TotalVolume { get; set; }

    public decimal UsedVolume { get; set; }

    public virtual ICollection<ProductReceipt> ProductReceipts { get; set; } = new List<ProductReceipt>();

    public virtual Warehouse Warehouse { get; set; } = null!;
}
