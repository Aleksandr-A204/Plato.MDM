using Microsoft.AspNetCore.Mvc;
using Plato.MDM.Models;
using Plato.MDM.Repositories;
using System.ComponentModel;

namespace Plato.MDM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MdmDirectoryDomainController : ControllerBase
    {
        private readonly ILogger<MdmDirectoryDomain> _logger;
        private readonly IMdmDirectoryDomainRepository _mdmRepository;

        public MdmDirectoryDomainController(ILogger<MdmDirectoryDomain> logger, IMdmDirectoryDomainRepository mdmRepository)
        {
            _logger = logger;
            _mdmRepository = mdmRepository;
        }

        [HttpGet]
        [Description("Получает все предметные области справочника")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllDomains()
        {
            try
            {
                return Ok(await _mdmRepository.GetAllDomainsAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении предметных областей справочника.");
                return BadRequest("Не удалось получить предметные области справочника.");
            }
        }

    }
}
