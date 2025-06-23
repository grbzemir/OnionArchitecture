using OnionArchitecture.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Dtos
{
    public class EventDto
    {
        public string Title { get; set; }
        public DateTimeOffset Date { get; set; }
        public Location Location { get; set; }
    }
}
