using ArtisanRoots.API.Commerce.Domain.Model.Aggregates;
using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.IAM.Domain.Model.Entities;

namespace ArtisanRoots.API.IAM.Domain.Model.Aggregates;

public partial class Artisan
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Status { get; set; }

    public int? RolesId { get; set; }

    public virtual ICollection<ArtisanCredential> ArtisanCredentials { get; set; } = new List<ArtisanCredential>();

    public virtual ICollection<NotificationArtisan> NotificationArtisans { get; set; } = new List<NotificationArtisan>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Role? Roles { get; set; }
}
