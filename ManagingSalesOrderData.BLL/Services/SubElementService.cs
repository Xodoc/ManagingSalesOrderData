using ManagingSalesOrderData.Shared.Dtos;
using ManagingSalesOrderData.BLL.Interfaces;
using ManagingSalesOrderData.DAL.Entities;
using ManagingSalesOrderData.DAL.Interfaces;
using Mapster;

namespace ManagingSalesOrderData.BLL.Services
{
    public class SubElementService : ISubElementService
    {
        private readonly ISubElementRepository _subElementRepository;
        private readonly IValidator _validator;

        public SubElementService(ISubElementRepository subElementRepository, IValidator validator)
        {
            _subElementRepository = subElementRepository;
            _validator = validator;
        }

        public async Task<SubElementDto> GetSubElementByIdAsync(int id)
        {
            var subElement = await _subElementRepository.GetByIdAsync(id);

            return subElement.Adapt<SubElementDto>();
        }

        public async Task<List<SubElementDto>> GetSubElementsAsync()
        {
            var subElements = await _subElementRepository.GetAllAsync();

            return subElements.Adapt<List<SubElementDto>>();
        }

        public async Task<SubElementDto> CreateSubElementAsync(SubElementDto subElementDto)
        {
            _validator.ValidateDto(subElementDto, subElementDto.Type);

            var subElement = await _subElementRepository.CreateAsync(subElementDto.Adapt<SubElement>());

            return subElement.Adapt<SubElementDto>();
        }

        public async Task<SubElementDto> UpdateSubElementAsync(SubElementDto subElementDto)
        {
            _validator.ValidateDto(subElementDto);

            var subElement = await _subElementRepository.UpdateAsync(subElementDto.Adapt<SubElement>());

            return subElement.Adapt<SubElementDto>();
        }

        public async Task DeleteSubElementByIdAsync(int id)
        {
            await _subElementRepository.DeleteByIdAsync(id);
        }
    }
}
