﻿using Bloqqer.DataAccess.Repositories.UnitOfWork;
using Bloqqer.DataAccess.Services.Interfaces;
using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.DataAccess.Services;

public sealed class UserService(IUnitOfWork unitOfWork) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ICollection<UserDTO>> GetAllUsers()
    {
        return (await _unitOfWork.ApplicationUsers.GetAll()).Select(a =>
            new UserDTO
            {
                FirstName = a.FirstName,
                MiddleName = a.MiddleName,
                LastName = a.LastName,
            }).ToList();
    }
}