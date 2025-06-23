using OnionArchitecture.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Abstract.Services
{
    public interface ITextServices
    {
        string FormatTextForEvent(IEnumerable<EventDto> evenItems);
    }
}
