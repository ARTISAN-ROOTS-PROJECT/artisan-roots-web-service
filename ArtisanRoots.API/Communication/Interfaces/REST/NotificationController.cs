using ArtisanRoots.API.Communication.Domain.Model.Queries;
using ArtisanRoots.API.Communication.Domain.Services.CommandServices;
using ArtisanRoots.API.Communication.Domain.Services.QueryServices;
using ArtisanRoots.API.Communication.Interfaces.REST.Resources.NotificationArtisan;
using ArtisanRoots.API.Communication.Interfaces.REST.Resources.NotificationOwner;
using ArtisanRoots.API.Communication.Interfaces.REST.Transform.NotificationArtisan;
using ArtisanRoots.API.Communication.Interfaces.REST.Transform.NotificationOwner;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace ArtisanRoots.API.Communication.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class NotificationController(INotificationArtisanCommandService notificationArtisanCommandService, 
    INotificationOwnerCommandService notificationOwnerCommandService, INotificationArtisanQueryService notificationArtisanQueryService,
    INotificationOwnerQueryService notificationOwnerQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new Notification Artisan",
        Description = "Creates a new Notification Artisan with given attributes",
        OperationId = "CreateNotificationArtisan"
    )]
    public async Task<IActionResult> CreateNotificationArtisan([FromBody]CreateNotificationArtisanResource resource)
    {
        try
        {
            var response = await notificationArtisanCommandService.
                Handle(CreateNotificationArtisanCommandFromResourceAssembler.ToCommandFromResorce(resource));

            var notificationArtisanResource = NotificationArtisanResourceFromEntityAssembler.ToResourceFromEntity(response!);

            return Ok(notificationArtisanResource);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Notification Artisans",
        Description = "Get All Notifications Artisans without parameters",
        OperationId = "GetAllNotificationArtisans"
    )]
    public async Task<IActionResult> GetAllNotificationArtisans()
    {
        try
        {
            var response = await notificationArtisanQueryService.Handle(new GetAllNotificationsQuery());

            var notificationArtisanResources = response.Select(NotificationArtisanResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(notificationArtisanResources);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create Notification Owner",
        Description = "Create notification owner with the given parameters",
        OperationId = "CreateNotificationOwner"
    )]
    public async Task<IActionResult> CreateNotificationOwner([FromBody] CreateNotificationOwnerResource resource)
    {
        try
        {
            var response = await notificationOwnerCommandService.
                Handle(CreateNotificationOwnerCommandFromResourceAssembler.ToCommandFromResource(resource));

            var notificationOwnerResource = NotificationOwnerResourceFromEntityAssembler.ToResourceFromEntity(response!);

            return Ok(notificationOwnerResource);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Notification Owners",
        Description = "Get All Notifications Owners with the given parameters",
        OperationId = "GetAllNotificationOwners"
    )]
    public async Task<IActionResult> GetAllNotificationOwners()
    {
        try
        {
            var response = await notificationOwnerQueryService.Handle(new GetAllNotificationsQuery());

            var resources = response.Select(NotificationOwnerResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(resources);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
