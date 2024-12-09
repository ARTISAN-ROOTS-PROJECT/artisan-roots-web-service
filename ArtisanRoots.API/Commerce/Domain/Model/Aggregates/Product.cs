using System;
using System.Collections.Generic;
using ArtisanRoots.API.Commerce.Domain.Model.Entities;
using ArtisanRoots.API.IAM.Domain.Model.Aggregates;
using ArtisanRoots.API.Models;

namespace ArtisanRoots.API.Commerce.Domain.Model.Aggregates;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? Stock { get; set; }

    public string? Photo { get; set; }

    public int? ArtisansId { get; set; }

    public int? CategoriesId { get; set; }

    public int? LocationsId { get; set; }

    public virtual Artisan? Artisans { get; set; }

    public virtual Category? Categories { get; set; }

    public virtual ICollection<DetailSale> DetailSales { get; set; } = new List<DetailSale>();

    public virtual Location? Locations { get; set; }
}
