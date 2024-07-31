using Microsoft.AspNetCore.Mvc;
using Plato.MDM.Models;
using Plato.MDM.Repositories;
using System.ComponentModel;

namespace Plato.MDM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MdmDirectoryVersionController : ControllerBase
    {
        private readonly ILogger<MdmDirectoryVersion> _logger;
        private readonly IMdmDirectoryVersionRepository _mdmRepository;

        public MdmDirectoryVersionController(ILogger<MdmDirectoryVersion> logger, IMdmDirectoryVersionRepository repository)
        {
            _logger = logger;
            _mdmRepository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAlVersions() => Ok(await _mdmRepository.GetAllDirectoryVersionsAsync());
    }
}
