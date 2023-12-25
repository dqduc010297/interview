using Domains.EM.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, IMediator mediator)
        {
            _logger = logger;

            this.mediator = mediator;
        }

        [HttpPost]
        [Route("paginate")]
        public async Task<IActionResult> GetAll([FromBody] GetAllEmployeeQuery.Request request)
        {
            return new OkObjectResult(await this.mediator.Send(request));
        }

        [HttpGet]
        [Route("total")]
        public async Task<IActionResult> GetTotalCounter()
        {
            var request = new GetTotalEmployeeCounterQuery.Request();
            return new OkObjectResult(await this.mediator.Send(request));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var request = new GetEmployeeByIdQuery.Request() { Id = id };
            return new OkObjectResult(await this.mediator.Send(request));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand.Request request)
        {
            return new OkObjectResult(await this.mediator.Send(request));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand.Request request)
        {
            return new OkObjectResult(await this.mediator.Send(request));
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var request = new DeleteEmployeeCommand.Request() { Id = id };
            return new OkObjectResult(await this.mediator.Send(request));
        }
    }
}
