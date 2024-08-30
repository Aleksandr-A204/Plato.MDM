using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllDirectories()
        {
            try
            {
                return Ok(await _mdmRepository.GetAllDirectoriesAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении справочников.");
                return BadRequest("Не удалось получить справочники.");
            }
        }

        [HttpPost]
        [Description("Добавляет справочник")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddDirectory([FromBody] MdmDirectory directory)
        {
            if (directory == null)
                return BadRequest("Некорректные данные.");

            try
            {
                await _mdmRepository.AddDirectoryAsync(directory);
                return CreatedAtAction(nameof(GetAllDirectories), new { id = directory.Id }, directory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при добавлении справочника.");
                return BadRequest("Не удалось добавить справочник.");
            }
        }

        [HttpPut("{id}")]
        [Description("Редактиирует справочник")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, [FromBody] MdmDirectory updatedDirectory)
        {
            try
            {
                await _mdmRepository.UpdateDirectoryAsync(id, updatedDirectory);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при редактировании справочника.");
                return BadRequest("Не удалось редактировать справочник.");
            }
        }

        [HttpDelete("{id}")]
        [Description("Удаляет справочник")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _mdmRepository.DeleteDirectoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении справочника.");
                return BadRequest("Не удалось удалить справочник.");
            }
        }
    }
}