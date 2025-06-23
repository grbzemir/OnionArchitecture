using OnionArchitecture.Application.Dtos;
using OnionArchitecture.Application.RequestParameters;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Abstract.Services
{
    public interface IEventService
    {
        Task CreateEventAsync(CreateEventDto createEventDto);
        Task<IEnumerable<EventDto>> GetAllEventsAsync(Pagination pagination);

       

    }
}
