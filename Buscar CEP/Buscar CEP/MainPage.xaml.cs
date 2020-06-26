using Buscar_CEP.Servicos;
using Buscar_CEP.Servicos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Buscar_CEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            try
            {
                if ((this.CEP.Text != "") && (this.CEP.Text != null))
                {
                    string cep = this.CEP.Text.Trim();
                    Endereco end = EnderecoViaCEP.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        DisplayAlert("Informação", "\nCEP:" + end.cep +
                                                   "\nLogradouro: " + end.logradouro +
                                                   "\nComplemento:" + end.complemento +
                                                   "\nBairro:" + end.bairro +
                                                   "\nLocalidade: " + end.localidade +  
                                                   "\nUF:" + end.uf, "Ok");
                    }
                    else
                    {
                        DisplayAlert("Informação", "CEP não foi encontrado", "Ok");
                    }
                   
                }
                else
                {
                    DisplayAlert("Atenção", "Campo CEP está em branco", "Ok");
                }

            }
            catch (Exception)
            {

                DisplayAlert("Atenção", "Erro ao buscar CEP", "Ok");
            }
        }
    }
}
