using System;
using System.Collections.Generic;
using ArtisanRoots.API.Commerce.Domain.Model.Aggregates;

namespace ArtisanRoots.API.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
