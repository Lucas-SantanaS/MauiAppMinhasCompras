using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Devices;
using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        { // Conectar ao banco de dados
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

//  ---- CRUD - Create, Read, Update, Delete ----


        // Inserir produto
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        // Atualizar produto
        public Task<int> Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";
            return _conn.ExecuteAsync(sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
        }

        // Deletar produto pelo Id
        public async Task<int> Delete(int id)
        {
            var produto = await _conn.FindAsync<Produto>(id);
            if (produto != null)
                return await _conn.DeleteAsync(produto);
            return 0;
        }

        // Listar todos os produtos
        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        // Buscar produto pelo descrição
        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE Descricao LIKE '%" + q + "%'";
            return _conn.QueryAsync<Produto>(sql);
        }
        // Busca por periodo
        public async Task<List<Produto>> BuscaProdutosPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return await _conn.Table<Produto>()
                                  .Where(p => p.DataCadastro >= dataInicio && p.DataCadastro <= dataFim)
                                  .ToListAsync();
        }
    }
}
