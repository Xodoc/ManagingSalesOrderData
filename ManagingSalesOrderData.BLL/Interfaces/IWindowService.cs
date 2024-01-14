using ManagingSalesOrderData.Shared.Dtos;

namespace ManagingSalesOrderData.BLL.Interfaces
{
    public interface IWindowService
    {
        Task<WindowDto> GetWindowByIdAsync(int id);

        Task<List<WindowDto>> GetWindowsAsync();

        Task<WindowDto> CreateWindowAsync(WindowDto WindowDto);

        Task<WindowDto> UpdateWindowAsync(WindowDto WindowDto);

        Task DeleteWindowByIdAsync(int id);
    }
}
