using AutoMapper;
using Identity.Application.Models;
using Identity.Application.Services.Interfaces;
using Identity.Domain.Common.Types;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using SharedModels.Exceptions;

namespace Identity.Application.Services
{
    /// <inheritdoc/>
    public class AccountService : IAccountService
    {
        private readonly IMapper mapper;

        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        /// <summary>
        /// Initializes a new <see cref="AccountService"/> instance.
        /// </summary>
        /// <param name="mapper">Entities to models mapper.</param>
        /// <param name="userManager"><see cref="UserManager{User}"/> implementation instance.</param>
        /// <param name="signInManager"><see cref="SignInManager{User}"/> implementation instance.</param>
        public AccountService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        /// <inheritdoc/>
        public async Task<UserInfo> RegisterUserAsync(RegisterUserModel registerUser, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(registerUser);

            var result = await userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
            {
                throw new FailCreateException("User has not been registered");
            }

            await userManager.AddToRoleAsync(user, RoleType.Client.ToString());

            await signInManager.SignInAsync(user, false);

            return mapper.Map<UserInfo>(user);
        }
    }
}
