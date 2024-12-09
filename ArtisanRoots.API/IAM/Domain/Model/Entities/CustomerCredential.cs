using System;
using System.Collections.Generic;
using ArtisanRoots.API.IAM.Domain.Model.Aggregates;

namespace ArtisanRoots.API.IAM.Domain.Model.Entities;

public partial class CustomerCredential
{
    public int Id { get; set; }

    public int? CustomersId { get; set; }

    public string? Password { get; set; }

    public virtual Customer? Customers { get; set; }
}
