using Identity.Application.Models;
using Identity.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebApi.Controllers
{
    /// <summary>
    /// Provides account endpoints.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="accountService">Account service.</param>
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Registers a User.
        /// </summary>
        /// <param name="registerUser">Create User request information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        [ProducesResponseType(typeof(UserInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterCustomerAsync([FromBody] RegisterUserModel registerUser, CancellationToken cancellationToken)
        {
            return Ok(await accountService.RegisterUserAsync(registerUser, cancellationToken));
        }
    }
}
