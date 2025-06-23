using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Abstract.Services;
using OnionArchitecture.Application.Dtos;
using OnionArchitecture.Application.RequestParameters;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Services
{
    public class EventServices : IEventService
    {
        private readonly ApplicationDbContext _context;
        public EventServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateEventAsync(CreateEventDto createEventDto)
        {
            if(createEventDto != null)
            {
                var newEvent = new Event()
                {
                    Title = createEventDto.Title,
                    Date = createEventDto.Date,
                    Location = createEventDto.Location,
                    
                };

                await _context.Events.AddAsync(newEvent);
                await _context.SaveChangesAsync();

            }

            else
            {
                throw new NullReferenceException();
            }
            

        }

        public async Task<IEnumerable<EventDto>> GetAllEventsAsync(Pagination pagination)
        {

            return await _context.Events
                 .AsNoTracking()
                 .Select(x => new EventDto()
                 {
                     Title = x.Title,
                     Date = x.Date,
                     Location = x.Location,
                 })
                 .Skip(pagination.PageCount * pagination.ItemCount)
                 .Take(pagination.ItemCount)
                 .ToListAsync();
        }

     }
   }

