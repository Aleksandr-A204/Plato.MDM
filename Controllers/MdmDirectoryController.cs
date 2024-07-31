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
        public async Task<ActionResult> GetAllDirectories() => Ok(await _mdmRepository.GetAllDirectoriesAsync());
    }
}