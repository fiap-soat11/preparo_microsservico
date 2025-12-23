using Application.Configurations;
using DataSource.Repositories.Interfaces;
using Domain;
using System.Linq;

namespace DataSource
{
    public class DataSource : Adapters.Gateways.Interfaces.IDataSource
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        
        public DataSource(IProdutoRepository produtoRepository, 
                          ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            
        }

        #region Categoria DataSource

        public async Task<IEnumerable<Categoria>> ListarCategorias()
        {
            return _categoriaRepository.ListarTodos();
        }



        #endregion

        #region Produto DataSource
        public async Task<Produto> IncluirProduto(Produto produto)
        {
            if (_produtoRepository.Existe(x => x.IdProduto == produto.IdProduto))
                throw new BusinessException("Produto ja existe");

            _produtoRepository.Inserir(produto);
            return produto;
        }

        public async Task AtualizarProduto(Produto produto)
        {
            _produtoRepository.Atualizar(produto);
        }

        public async Task ExcluirProduto(Produto produto)
        {
            if (!_produtoRepository.Existe(x => x.IdProduto == produto.IdProduto))
                throw new BusinessException("Produto não cadastrado");

            _produtoRepository.Excluir(produto.IdProduto);
        }

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            return _produtoRepository.ListarTodos();
        }

        public async Task<List<Produto>> BuscarProdutosCategoria(int IdCategoria)
        {
            return _produtoRepository.Buscar(x => x.IdCategoria == IdCategoria).ToList();
        }

        public async Task<Produto> BuscarProdutoPorProdutoID(int produtoID)
        {
            return _produtoRepository.BuscarPorId(produtoID);
        }

        #endregion

    }
}