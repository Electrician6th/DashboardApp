using System;
using System.Collections.Generic;

namespace DashboardApp.Models;

public partial class Product
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Sku { get; set; } = null!;

    public DateOnly ProductionDate { get; set; }

    public DateOnly ExpirationDate { get; set; }

    public int PackageLength { get; set; }

    public int PackageWidth { get; set; }

    public int PackageHeight { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductReceipt> ProductReceipts { get; set; } = new List<ProductReceipt>();
}
