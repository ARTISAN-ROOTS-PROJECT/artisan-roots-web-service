using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.Communication.Domain.Model.Commands;
using ArtisanRoots.API.Communication.Domain.Model.Exceptions;
using ArtisanRoots.API.Communication.Domain.Repositories;
using ArtisanRoots.API.Communication.Domain.Services.CommandServices;
using ArtisanRoots.API.Shared.Domain.Repositories;

namespace ArtisanRoots.API.Communication.Application.Internal.CommandServices;

public class NotificationOwnerCommandService(INotificationOwnerRepository notificationOwnerRepository, IUnitOfWork unitOfWork) : INotificationOwnerCommandService
{
    public async Task<NotificationOwner?> Handle(CreateNotificationOwnerCommand command)
    {
        if (string.IsNullOrEmpty(command.Title) || string.IsNullOrEmpty(command.Content) || command.OwnersId == 0)
            throw new AnyAttributeCanBeEmptyOrNullException();

        var entity = new NotificationOwner(command);

        await notificationOwnerRepository.AddAsync(entity);

        await unitOfWork.CommitAsync();

        return entity;
    }

}

