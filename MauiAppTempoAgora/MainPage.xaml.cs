using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;
using System.Threading.Tasks;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

       
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if(t != null)
                    {
                        string dados_previsao = "";
                        dados_previsao = $"Latitude:{t.lat} \n" +
                            $"Longitude:{t.lon} \n" +
                            $"Nascer do sol: {t.sunrise} \n" +
                            $"POr do sol: {t.sunset} \n" +
                            $"Temp Máx:{t.temp_max} \n" +
                            $"Tempo Min:{t.temp_min} \n";

                    }else

                    {
                        lbl_res.Text = "Sem dados de Previsão";
                    }
                } else
                {
                    lbl_res.Text = "Preencha a cidade.";
                }

            }catch(Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }

        }
    }

}
