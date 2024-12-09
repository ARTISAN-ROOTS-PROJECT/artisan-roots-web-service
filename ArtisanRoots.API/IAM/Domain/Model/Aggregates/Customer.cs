using System;
using System.Collections.Generic;
using ArtisanRoots.API.Commerce.Domain.Model.Entities;
using ArtisanRoots.API.IAM.Domain.Model.Entities;

namespace ArtisanRoots.API.IAM.Domain.Model.Aggregates;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Status { get; set; }

    public int? RolesId { get; set; }

    public virtual ICollection<CustomerCredential> CustomerCredentials { get; set; } = new List<CustomerCredential>();

    public virtual ICollection<OrderSale> OrderSales { get; set; } = new List<OrderSale>();

    public virtual Role? Roles { get; set; }
}
