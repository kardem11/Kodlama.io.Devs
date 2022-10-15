using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.Auths.AuthServıce;
using Devs.Application.Features.Users.Dtos;
using Devs.Application.Features.Users.Rules;
using Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Users.Commands.RegisterCommand
{
    public class RegisterUserCommand : IRequest<RegisteredUserDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisteredUserDto>
        {
            private readonly IAuthService _authService;
            private readonly IUserRepository _userRepository;

            private readonly UserBusinessRules _rules;

            public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules rules, IAuthService authService)
            {
                _userRepository = userRepository;

                _rules = rules;
                _authService = authService;
            }

            public async Task<RegisteredUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await _rules.EmailCanNotBeDuplicated(request.UserForRegisterDto.Email);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);


                User newUser = new()
                {
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    Status = true
                };

                User createdUser = await _userRepository.AddAsync(newUser);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisteredUserDto registeredUserDto = new()
                {
                    RefreshToken = addedRefreshToken,
                    AccessToken = createdAccessToken,

                };
                return registeredUserDto;

            }
        }
    }

}

