using SaleWebMvc.Models;

namespace SaleWebMvc.Repository {

    /*
     A interface recebe um objeto de ContatoModel. Quando o controller 
    passa esse objeto de ContatoModel, ele entra lá no ContatoRepository, 
    que é onde o Adicionar está fazendo a lógica. 
     */
    public interface IContatoRepository {

        // READ ALL
        List<ContatoModel> GetContatoList();
        // CREAT
        ContatoModel Adicionar(ContatoModel contato);

        // UPDATE
        ContatoModel ShowIdElements(int id);
        ContatoModel Alterar(ContatoModel contato);

        // DELETAR
        bool Exclusao(int id);

    }
}
