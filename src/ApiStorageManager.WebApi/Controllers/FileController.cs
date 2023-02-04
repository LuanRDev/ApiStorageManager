using ApiStorageManager.Application.Interfaces;
using ApiStorageManager.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ApiStorageManager.WebApi.Controllers
{
    public class FileController : ApiController
    {
        private readonly IFileAppService _fileAppService;

        public FileController(IFileAppService fileAppService)
        {
            _fileAppService = fileAppService;
        }

        [HttpGet("file/{empresa}/{codigoEvento}/{id:guid}")]
        public async Task<FileViewModel> Get(string empresa, string codigoEvento, Guid id)
        {
            return await _fileAppService.GetById(id, empresa, codigoEvento);
        }

        [HttpPost("file")]
        public async Task<IActionResult> Post([FromBody]FileViewModel fileViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _fileAppService.Upload(fileViewModel));
        }

        [HttpPut("file")]
        public async Task<IActionResult> Put([FromBody]FileViewModel fileViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _fileAppService.Update(fileViewModel));
        }
    }
}
