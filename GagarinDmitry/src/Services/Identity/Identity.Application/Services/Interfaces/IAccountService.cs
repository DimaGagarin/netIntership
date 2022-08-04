using Identity.Application.Models;

namespace Identity.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<UserInfo> RegisterUser(RegisterUserModel registerUser, CancellationToken cancellationToken);
    }
}
