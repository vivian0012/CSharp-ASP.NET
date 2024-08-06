using Microsoft.AspNetCore.Mvc;
using SaleWebMvc.Models;
using SaleWebMvc.Repository;

namespace SaleWebMvc.Controllers {
    public class ContatoController : Controller {
        
        private readonly IContatoRepository _contatoRepository;
        
        public ContatoController(IContatoRepository contatoRepository) {
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index() {
            List<ContatoModel> contatos = _contatoRepository.GetContatoList();
            return View(contatos);
        }

        // GET
        public IActionResult Criar() {
            return View();
        }
        
        [HttpPost]
        public IActionResult Criar(ContatoModel obj) { 
            _contatoRepository.Adicionar(obj);
            return RedirectToAction("Index");
        }

        // UPDATE
        public IActionResult Editar(int id) {
            ContatoModel contato = _contatoRepository.ShowIdElements(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult Alterar(ContatoModel obj) {
            _contatoRepository.Alterar(obj);
            return RedirectToAction("Index");
        }

        // DELETAR
        public IActionResult Apagar(int id) {
            ContatoModel contato = _contatoRepository.ShowIdElements(id);
            return View(contato);
        }
        public IActionResult ConfirmarExclusao(int id) {
            _contatoRepository.Exclusao(id);
            return RedirectToAction("Index");
        }

    }
}
