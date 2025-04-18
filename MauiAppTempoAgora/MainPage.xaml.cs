﻿using MauiAppTempoAgora.Models;
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
                            $"Descrição textual do clima:{t.description} \n" +
                            $"Velocidade do vento:{t.speed} \n" +
                            $"Visibilidade:{t.visibility} \n" +
                            $"Nascer do sol: {t.sunrise} \n" +
                            $"Por do sol: {t.sunset} \n" +
                            $"Temp Máx:{t.temp_max} \n" +
                            $"Tempo Min:{t.temp_min} \n";

                        lbl_res.Text = dados_previsao;

                    }else

                    {
                        lbl_res.Text = "Sem dados de previsão, nome da cidade não encontrado!";
                    }
                } else
                {
                    lbl_res.Text = "Preencha a cidade.";
                }



            }catch(Exception ex)
            {
                await DisplayAlert("Ops sem conexão com a internet", ex.Message, "OK");
            }

        }
    }

}
