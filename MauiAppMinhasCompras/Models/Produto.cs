using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        string _descricao;
        double _quantidade;
        double _preco;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descricao { 
            get => _descricao;
            set 
            {
                if (value == null)
                {
                    throw new Exception("A descrição não pode ficar vazia!");
                }
                _descricao = value;
            }
        }

        public double Quantidade{
            get => _quantidade;
            set
            {
                if (value == 0)
                {
                    throw new Exception("O campo quantidade não pode ficar vazio!");
                }if (value < 0)
                {
                    throw new Exception("A quantidade não pode ser negativa!");
                }
                _quantidade = value;
            }
        }
        public double Preco { 
            get => _preco; 
            set{
                if (value < 0)
                {
                    throw new Exception("O preço não pode ser negativo!");
                }
               _preco = value;
            }
        }

        public double Total { get => Quantidade * Preco; }
        
    }
}
