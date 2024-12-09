using System;
using System.Collections.Generic;
using ArtisanRoots.API.Commerce.Domain.Model.Aggregates;

namespace ArtisanRoots.API.Commerce.Domain.Model.Entities;

public partial class DetailSale
{
    public int Id { get; set; }

    public int? OrderSalesId { get; set; }

    public int? Quantity { get; set; }

    public int? ProductsId { get; set; }

    public decimal? TotalCost { get; set; }

    public virtual OrderSale? OrderSales { get; set; }

    public virtual Product? Products { get; set; }
}
