using Microsoft.AspNetCore.Mvc;
using Plato.MDM.Models;
using Plato.MDM.Repositories;
using System.ComponentModel;

namespace Plato.MDM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MdmDirectoryLevelController : ControllerBase
    {
        private readonly ILogger<MdmDirectoryLevel> _logger;
        private readonly IMdmDirectoryLevelRepository _mdmRepository;

        public MdmDirectoryLevelController(ILogger<MdmDirectoryLevel> logger, IMdmDirectoryLevelRepository mdmRepository)
        {
            _logger = logger;
            _mdmRepository = mdmRepository;
        }

        [HttpGet]
        [Description("Получает все уровни справочника")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllLevels()
        {
            try
            {
                return Ok(await _mdmRepository.GetAllLevelsAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении уровней справочника.");
                return BadRequest("Не удалось получить уровни справочника.");
            }
        }
    }
}