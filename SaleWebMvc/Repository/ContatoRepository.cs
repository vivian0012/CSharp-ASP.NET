using SaleWebMvc.Data;
using SaleWebMvc.Models;

// Service do SpringBoot
namespace SaleWebMvc.Repository {
    public class ContatoRepository : IContatoRepository {

        /*
         Quando você marca um campo com readonly, 
         você está garantindo que o campo não pode ser alterado após a inicialização, 
         exceto no construtor da classe. */

        private readonly BancoContexts _bancoContexts; 

        /*
        Por context ser o responsável pelo CRUD, daqui você está chamandoo para que o 
        Context execute todas essas funções CRUD. 
        Repare que usamos o _bancoContexts para executar as funções. */
        public ContatoRepository(BancoContexts bancoContexts) {
            _bancoContexts = bancoContexts;
        }

        // READ ALL
        public List<ContatoModel> GetContatoList() {
            return _bancoContexts.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato) {

            // Gravar para o banco de dados
            _bancoContexts.Add(contato);
            _bancoContexts.SaveChanges();
            return contato;
        }
        // UPDATE
        public ContatoModel ShowIdElements(int id) => _bancoContexts.Contatos.FirstOrDefault(x => x.Id == id);
        public ContatoModel Alterar(ContatoModel contato) {
            ContatoModel contatoDb = ShowIdElements(contato.Id);
            if (contatoDb == null) {
                throw new Exception("Houve um erro na atualização do contato");
            }
            else {
                contatoDb.Nome = contato.Nome;
                contatoDb.Email = contato.Email;
                contatoDb.Phone = contato.Phone;
                _bancoContexts.Update(contatoDb);
                _bancoContexts.SaveChanges();
                return contatoDb;
            }
        }

        public bool Exclusao(int id) {

            ContatoModel contatoDb = ShowIdElements(id);
            if (contatoDb == null) {
                throw new Exception("Houve um erro na deleção do contato");
            }
            else {
                _bancoContexts.Contatos.Remove(contatoDb);
                _bancoContexts.SaveChanges();
                return true;
            }
        }
            
        
    }
}
