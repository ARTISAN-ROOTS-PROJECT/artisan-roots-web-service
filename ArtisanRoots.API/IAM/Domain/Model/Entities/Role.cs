using System;
using System.Collections.Generic;
using ArtisanRoots.API.IAM.Domain.Model.Aggregates;

namespace ArtisanRoots.API.IAM.Domain.Model.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Artisan> Artisans { get; set; } = new List<Artisan>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Owner> Owners { get; set; } = new List<Owner>();
}
