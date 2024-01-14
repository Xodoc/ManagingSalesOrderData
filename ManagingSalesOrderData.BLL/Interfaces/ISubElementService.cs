using ManagingSalesOrderData.Shared.Dtos;

namespace ManagingSalesOrderData.BLL.Interfaces
{
    public interface ISubElementService
    {
        Task<SubElementDto> GetSubElementByIdAsync(int id);

        Task<List<SubElementDto>> GetSubElementsAsync();

        Task<SubElementDto> CreateSubElementAsync(SubElementDto SubElementDto);

        Task<SubElementDto> UpdateSubElementAsync(SubElementDto SubElementDto);

        Task DeleteSubElementByIdAsync(int id);
    }
}
