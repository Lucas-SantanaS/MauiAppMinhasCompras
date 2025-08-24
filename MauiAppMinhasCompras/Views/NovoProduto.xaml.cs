// NovoProduto.xaml.cs == Código backend do XAML.
using MauiAppMinhasCompras.Models;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        { // Criar objeto Produto e preencher com dados da tela
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)

            };
            // Inserir no banco de dados
            await App.Db.Insert(p);
            // Voltar para a página anterior (ListaProduto)
            await DisplayAlert("Sucesso!", "Registro inserido.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("ERRO", ex.Message, "OK");
        }
    }
}