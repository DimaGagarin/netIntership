using Identity.Application.Models;

namespace Identity.Application.Services.Interfaces
{
    /// <summary>
    /// Represents account service.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Registers a user and monitors cancellation request
        /// </summary>
        /// <param name="registerUser">User to register</param>
        /// <param name="cancellationToken">Cancellation token to cancel an asynchronous operation.</param>
        /// <returns>Task that represents an asynchronous operation with the registered user information</returns>
        Task<UserInfo> RegisterUserAsync(RegisterUserModel registerUser, CancellationToken cancellationToken);
    }
}
