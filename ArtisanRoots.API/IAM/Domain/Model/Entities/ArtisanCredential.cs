using System;
using System.Collections.Generic;
using ArtisanRoots.API.IAM.Domain.Model.Aggregates;

namespace ArtisanRoots.API.IAM.Domain.Model.Entities;

public partial class ArtisanCredential
{
    public int Id { get; set; }

    public int? ArtisansId { get; set; }

    public string? Password { get; set; }

    public virtual Artisan? Artisans { get; set; }
}
