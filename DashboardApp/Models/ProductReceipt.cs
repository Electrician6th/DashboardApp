using System;
using System.Collections.Generic;

namespace DashboardApp.Models;

public partial class ProductReceipt
{
    public int Id { get; set; }

    public int ReceiptId { get; set; }

    public int ProductId { get; set; }

    public int FridgeId { get; set; }

    public virtual Fridge Fridge { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Receipt Receipt { get; set; } = null!;
}
