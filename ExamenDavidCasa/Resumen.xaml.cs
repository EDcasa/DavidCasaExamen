using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenDavidCasa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resumen : ContentPage
    {
        public Resumen(String usuario, String nombre, String valorPagar)
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            lblUsuario.Text = usuario;
            txtNombre.Text = nombre;
            txtMontoFinal.Text = valorPagar;
        }

        private async void btnFinalizar_Clicked(object sender, EventArgs e)
        {

            var answer = await DisplayAlert("Inscripcion finalizada", "El proceso ha finalizado con exito", "Aceptar", "Cancelar");
            if (answer == true) // Si la respuesta es Ok
            {
                await Navigation.PushAsync(new Registro(lblUsuario.Text));
            }
        }
    }
}