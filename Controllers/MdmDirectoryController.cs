using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plato.MDM.Models;
using Plato.MDM.Repositories;
using System.ComponentModel;

namespace Plato.MDM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MdmDirectoryController : ControllerBase
    {
        private readonly ILogger<MdmDirectory> _logger;
        private readonly IMdmDirectoryRepository _mdmRepository;

        public MdmDirectoryController(ILogger<MdmDirectory> logger, IMdmDirectoryRepository mdmRepository)
        {
            _logger = logger;
            _mdmRepository = mdmRepository;
        }

        [HttpGet]
        [Description("Получает все справочники")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllDirectories()
            => Ok(await _mdmRepository.GetAllDirectoriesAsync());

        [HttpPost]
        [Description("Добавляет справочник")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add([FromBody] MdmDirectory directory)
        {
            _mdmRepository.AddDirectoryAsync(directory);
            return Created("URI of the created entity", directory);
        }

        [HttpPut("{id}")]
        [Description("Редактиирует справочник")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Edit([FromBody] MdmDirectory directory)
        {
            _mdmRepository.EditDirectoryAsync(directory);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Description("Удаляет справочник")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Guid id)
        {

            return NoContent();
        }
    }
}