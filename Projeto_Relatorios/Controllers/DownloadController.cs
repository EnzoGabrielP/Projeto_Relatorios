using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Projeto_Relatorios.Controllers
{
    public class DownloadController : Controller
    {
        private readonly string _caminhoDosArquivos = @"C:\Users\Users\Desktop\Projeto_Relatorios-master\Projeto_Relatorios\bin\Debug\netcoreapp3.1\Relatorios";

        [HttpGet]
        public IActionResult Download(string nomeArquivo)
        {
            if (string.IsNullOrEmpty(nomeArquivo))
                return BadRequest("Nome do arquivo inválido.");

            var caminhoCompleto = Path.Combine(_caminhoDosArquivos, nomeArquivo);

            if (!System.IO.File.Exists(caminhoCompleto))
                return NotFound("Arquivo não encontrado.");

            var conteudoArquivo = System.IO.File.ReadAllBytes(caminhoCompleto);
            var tipoMime = "application/octet-stream"; 

            return File(conteudoArquivo, tipoMime, nomeArquivo);
        }
    }
}
