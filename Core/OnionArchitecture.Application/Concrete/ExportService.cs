using OnionArchitecture.Application.Abstract.Services;
using OnionArchitecture.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Concrete
{
    public class ExportService
    {
        private readonly ITextServices _textServices;
        private readonly IFileService _fileService;
        public ExportService(ITextServices textServices , IFileService fileService)
        {
            _textServices = textServices;
            _fileService = fileService;    
        }

        public async Task ExportEventsAsync(IEnumerable<EventDto> eventItems, string filePath)
        {
            if (eventItems == null || !eventItems.Any())
            {
                throw new ArgumentException("Event items cannot be null or empty", nameof(eventItems));
            }

            var formattedText = _textServices.FormatTextForEvent(eventItems);
            await _fileService.SaveTextAsync(formattedText, filePath);
        }
    }
}
