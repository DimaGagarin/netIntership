using Basket.Application.Models;
using Basket.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basket.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
        {
            return Ok(await ticketService.GetAsync(id, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TicketInfo ticketInfo, CancellationToken cancellationToken)
        {
            return Ok(await ticketService.CreateAsync(ticketInfo, cancellationToken));
        }
    }
}
