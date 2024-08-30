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
        [Description("�������� ��� �����������")]
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
                _logger.LogError(ex, "������ ��� ��������� ������������.");
                return BadRequest("�� ������� �������� �����������.");
            }
        }

        [HttpPost]
        [Description("��������� ����������")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddDirectory([FromBody] MdmDirectory directory)
        {
            if (directory == null)
                return BadRequest("������������ ������.");

            try
            {
                await _mdmRepository.AddDirectoryAsync(directory);
                return CreatedAtAction(nameof(GetAllDirectories), new { id = directory.Id }, directory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "������ ��� ���������� �����������.");
                return BadRequest("�� ������� �������� ����������.");
            }
        }

        [HttpPut("{id}")]
        [Description("������������ ����������")]
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
                _logger.LogError(ex, "������ ��� �������������� �����������.");
                return BadRequest("�� ������� ������������� ����������.");
            }
        }

        [HttpDelete("{id}")]
        [Description("������� ����������")]
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
                _logger.LogError(ex, "������ ��� �������� �����������.");
                return BadRequest("�� ������� ������� ����������.");
            }
        }
    }
}