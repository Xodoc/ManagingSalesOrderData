using ManagingSalesOrderData.Shared.Dtos;
using ManagingSalesOrderData.BLL.Interfaces;
using ManagingSalesOrderData.DAL.Entities;
using ManagingSalesOrderData.DAL.Interfaces;
using Mapster;

namespace ManagingSalesOrderData.BLL.Services
{
    public class WindowService : IWindowService
    {
        private readonly IWindowRepository _windowRepository;
        private readonly IValidator _validator;

        public WindowService(IWindowRepository windowRepository, IValidator validator)
        {
            _windowRepository = windowRepository;
            _validator = validator;
        }

        public async Task<WindowDto> GetWindowByIdAsync(int id)
        {
            var window = await _windowRepository.GetByIdAsync(id);

            return window.Adapt<WindowDto>();
        }

        public async Task<List<WindowDto>> GetWindowsAsync()
        {
            var windows = await _windowRepository.GetAllAsync();

            return windows.Adapt<List<WindowDto>>();
        }

        public async Task<WindowDto> CreateWindowAsync(WindowDto windowDto)
        {
            _validator.ValidateDto(windowDto, windowDto.Name);

            var window = await _windowRepository.CreateAsync(windowDto.Adapt<Window>());

            return window.Adapt<WindowDto>();
        }

        public async Task<WindowDto> UpdateWindowAsync(WindowDto windowDto)
        {
            _validator.ValidateDto(windowDto);

            var window = await _windowRepository.UpdateAsync(windowDto.Adapt<Window>());

            return window.Adapt<WindowDto>();
        }

        public async Task DeleteWindowByIdAsync(int id)
        {
            await _windowRepository.DeleteByIdAsync(id);
        }
    }
}
