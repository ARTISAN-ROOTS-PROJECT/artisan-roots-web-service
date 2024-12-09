using System;
using System.Collections.Generic;
using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.IAM.Domain.Model.Entities;

namespace ArtisanRoots.API.IAM.Domain.Model.Aggregates;

public partial class Owner
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Status { get; set; }

    public int? RolesId { get; set; }

    public virtual ICollection<OwnerCredential> OwnerCredentials { get; set; } = new List<OwnerCredential>();

    public virtual ICollection<NotificationOwner> NotificationOwners { get; set; } = new List<NotificationOwner>();

    public virtual Role? Roles { get; set; }
}
