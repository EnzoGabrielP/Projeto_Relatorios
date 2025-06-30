using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Projeto_Relatorios.Controllers
{
    public class DeleteController : Controller
    {
         private readonly string _caminhoDosArquivos = @"C:\Users\Users\Desktop\Projeto_Relatorios-master\Projeto_Relatorios\bin\Debug\netcoreapp3.1\Relatorios";
        [HttpPost]
        public IActionResult Deleta(string nomeArquivo)
        {
            if (string.IsNullOrEmpty(nomeArquivo))
                return BadRequest("Nome do arquivo inválido.");

            var caminhoCompleto = Path.Combine(_caminhoDosArquivos, nomeArquivo);

            if (System.IO.File.Exists(caminhoCompleto))
                System.IO.File.Delete(caminhoCompleto);

            TempData["Mensagem"] = "Arquivo deletado com sucesso!";
            return RedirectToAction("Index","Home");

            
        }
    }
}
