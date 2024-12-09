using System;
using System.Collections.Generic;
using ArtisanRoots.API.IAM.Domain.Model.Aggregates;

namespace ArtisanRoots.API.IAM.Domain.Model.Entities;

public partial class OwnerCredential
{
    public int Id { get; set; }

    public int? OwnersId { get; set; }

    public string? Password { get; set; }

    public virtual Owner? Owners { get; set; }
}
