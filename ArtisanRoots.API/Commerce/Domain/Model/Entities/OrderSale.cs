using System;
using System.Collections.Generic;
using ArtisanRoots.API.IAM.Domain.Model.Aggregates;

namespace ArtisanRoots.API.Commerce.Domain.Model.Entities;

public partial class OrderSale
{
    public int Id { get; set; }

    public int? CustomersId { get; set; }

    public decimal? FinalCost { get; set; }

    public virtual Customer? Customers { get; set; }

    public virtual ICollection<DetailSale> DetailSales { get; set; } = new List<DetailSale>();
}
