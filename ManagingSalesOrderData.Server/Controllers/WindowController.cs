using ManagingSalesOrderData.Shared.Dtos;
using ManagingSalesOrderData.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManagingSalesOrderData.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly IWindowService _windowService;

        public WindowController(IWindowService windowService)
        {
            _windowService = windowService;
        }

        [HttpGet("{id}", Name = "GetWindowById")]
        public async Task<IActionResult> GetWindowById([Required][FromRoute] int id)
        {
            return Ok(await _windowService.GetWindowByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetWindows()
        {
            return Ok(await _windowService.GetWindowsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateWindow([FromBody] WindowDto dto)
        {
            return Ok(await _windowService.CreateWindowAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWindow([FromBody] WindowDto dto)
        {
            return Ok(await _windowService.UpdateWindowAsync(dto));
        }

        [HttpDelete("{id}", Name = "DeleteWindowById")]
        public async Task<IActionResult> DeleteWindowById([Required][FromRoute] int id)
        {
            await _windowService.DeleteWindowByIdAsync(id);

            return Ok();
        }
    }
}
