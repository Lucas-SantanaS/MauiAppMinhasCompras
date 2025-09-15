namespace MauiAppMinhasCompras.Views;
using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

public partial class NewPage1 : ContentPage
{
    public NewPage1()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        // Pega todos os produtos do banco de dados e atribui à CollectionView
        var todosOsProdutos = await App.Db.GetAll();
        lst_produtos.ItemsSource = todosOsProdutos;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            DateTime dataInicio = data_inicio.Date;
            DateTime dataFim = data_fim.Date;

            DateTime dataFimComHoras = dataFim.AddDays(1).AddSeconds(-1);

            if (dataInicio > dataFimComHoras)
            {
                await DisplayAlert("Erro", "A data de início não pode ser maior que a data de fim.", "OK");
                return;
            }

            var produtosFiltrados = await App.Db.BuscaProdutosPorPeriodo(dataInicio, dataFimComHoras);

            // Atualiza a CollectionView para exibir os resultados do filtro
            lst_produtos.ItemsSource = produtosFiltrados;
        }
        catch (Exception ex)
        {
            await DisplayAlert("ERRO", ex.Message, "OK");
        }
    }
}