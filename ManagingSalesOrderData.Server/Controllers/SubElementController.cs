using ManagingSalesOrderData.Shared.Dtos;
using ManagingSalesOrderData.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManagingSalesOrderData.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubElementController : ControllerBase
    {
        private readonly ISubElementService _subElementService;

        public SubElementController(ISubElementService subElementService)
        {
            _subElementService = subElementService;
        }

        [HttpGet("{id}", Name = "GetSubElementById")]
        public async Task<IActionResult> GetSubElemetById([Required][FromRoute] int id)
        {
            return Ok(await _subElementService.GetSubElementByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetSubElements()
        {
            return Ok(await _subElementService.GetSubElementsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubElement([FromBody] SubElementDto dto)
        {
            return Ok(await _subElementService.CreateSubElementAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubElement([FromBody] SubElementDto dto)
        {
            return Ok(await _subElementService.UpdateSubElementAsync(dto));
        }

        [HttpDelete("{id}", Name = "DeleteSubElementById")]
        public async Task<IActionResult> DeleteSubElementById([Required][FromRoute] int id)
        {
            await _subElementService.DeleteSubElementByIdAsync(id);

            return Ok();
        }
    }
}
