using System;
using System.Collections.Generic;

namespace DashboardApp.Models;

public partial class Receipt
{
    public int Id { get; set; }

    public int SupplierId { get; set; }

    public string Number { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual ICollection<ProductReceipt> ProductReceipts { get; set; } = new List<ProductReceipt>();

    public virtual Supplier Supplier { get; set; } = null!;
}
