using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Projeto_Relatorios.Controllers
{
    public class UploadController : Controller
    {
        private readonly string _caminhoDestino = @"C:\Users\Users\Desktop\Projeto_Relatorios-master\Projeto_Relatorios\bin\Debug\netcoreapp3.1\Relatorios";

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Enviar(IFormFile arquivo)
        {
            if (arquivo != null && arquivo.Length > 0)
            {
                var caminhoArquivo = Path.Combine(_caminhoDestino, Path.GetFileName(arquivo.FileName));

                using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    await arquivo.CopyToAsync(stream);
                }

                TempData["Mensagem"] = "Arquivo enviado com sucesso!";
                return RedirectToAction("Index");
            }

            TempData["Mensagem"] = "Selecione um arquivo válido.";
            return RedirectToAction("Index");
        }
    }
}
