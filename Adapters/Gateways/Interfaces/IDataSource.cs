using Domain;

namespace Adapters.Gateways.Interfaces
{
    public interface IDataSource
    {
       
        #region Categoria DataSource
        Task<IEnumerable<Categoria>> ListarCategorias();

        #endregion

        #region Produto DataSource
        Task<Produto> IncluirProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task ExcluirProduto(Produto produto);
        Task<IEnumerable<Produto>> ListarProdutos();
        Task<List<Produto>> BuscarProdutosCategoria(int IdCategoria);
        Task<Produto> BuscarProdutoPorProdutoID(int produtoID);
        #endregion

    }

} 
