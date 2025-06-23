using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Abstract.Services;
using OnionArchitecture.Application.Concrete;
using OnionArchitecture.Application.Dtos;
using OnionArchitecture.Application.RequestParameters;
using System.ComponentModel.Design;

namespace OnionArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly ExportService _exportService;
        public EventsController(IEventService eventService , ExportService exportService)
        {
            _eventService = eventService;
            _exportService = exportService;

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllEvents([FromQuery] Pagination pagination)
        {
            var events = await _eventService.GetAllEventsAsync(pagination);
            return Ok(events);
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto createEventDto)
        {
            if (createEventDto == null)
            {
                return BadRequest("Invalid event data.");
            }

            await _eventService.CreateEventAsync(createEventDto);

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ExportEvents([FromQuery] Pagination pagination, string path)
        {
            var events = await _eventService.GetAllEventsAsync(pagination);

            await _exportService.ExportEventsAsync(events, path);

            return Ok();
        }
    }
}
