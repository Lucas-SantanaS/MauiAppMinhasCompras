// ListaProduto.xaml.cs == C�digo por tr�s do arquivo XAML

namespace MauiAppMinhasCompras.Views;
public partial class ListaProduto : ContentPage
{
    public ListaProduto()
    {
        InitializeComponent();
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            DisplayAlert("ERRO", ex.Message, "OK");
        }
    }
}