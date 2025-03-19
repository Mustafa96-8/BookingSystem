using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.ValueObjects;
using BookingSystem.Infrastructure.Repositories;
using Contracts.DTO;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<IEnumerable<User>,Error>> GetAll(CancellationToken ct)
        {
            var users = await _userRepository.Get(ct);
            if(users.IsFailure)
                return users.Error;
            return users.Value.ToList();
        }

        public async Task<Result<User,Error>> GetById(Guid? id, CancellationToken ct)
        {
            if(id == null)
                return Errors.General.ValueIsInvalid("id");
            var user = await _userRepository.GetById((Guid)id, ct);
            if(user.IsFailure)
                return user.Error;
            return user.Value;

        }

        public async Task<Result<Guid,Error>> Create(UserDTO request,CancellationToken ct)
        {
            var phone = PhoneNumber.Create(request.PhoneNumber);
            if(phone.IsFailure)
                return phone.Error;
            var user = User.Create(request.Name, request.Email, request.Password, phone.Value);
            if(user.IsFailure)
                return user.Error;
            var response = await _userRepository.Add(user.Value, ct);
            if(response.IsFailure)
                return response.Error;
            return response.Value;

        }

    }
}
