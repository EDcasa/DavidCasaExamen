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
    public partial class Registro : ContentPage
    {
        public Registro(String usuario)
        {
            NavigationPage.SetHasBackButton(this, false);
            
            InitializeComponent();
            lblUsuario.Text = usuario;
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            if (txtMontoInicial.Text != null && Double.Parse(txtMontoInicial.Text) > 0)
            {
                String montoInicial = txtMontoInicial.Text;
                Double valorAproximado = 1800;
                Double valorRestante = valorAproximado - Double.Parse(montoInicial);
                Double cuotasMensuales = Math.Round((valorRestante / 3) + (valorAproximado * 0.05), 2);
                txtCuotaMensual.Text = cuotasMensuales.ToString();
                Double valorFinal = Math.Round((cuotasMensuales * 3) + Double.Parse(montoInicial), 2);
                txtValorFinal.Text = valorFinal.ToString();
            }
            else
            {
                DisplayAlert("Campos requeridos", "Ingrese el monto inicial", "Aceptar");
            }
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (txtNombre.Text == null || txtApellidos.Text == null) {
                await DisplayAlert("Campos requeridos", "Ingrese la informacion solicitada", "Aceptar");
                
            }else if (txtMontoInicial.Text == null) {
                await DisplayAlert("Campos requeridos", "Ingrese la informacion solicitada", "Aceptar");

            }
            else
            {
                var answer = await DisplayAlert("Ingreso exitoso", "Elemento guardado con exito", "Aceptar", "Cancelar");
                if (answer == true) // Si la respuesta es Ok
                {
                    await Navigation.PushAsync(new Resumen(lblUsuario.Text, txtNombre.Text + " " + txtApellidos.Text, txtValorFinal.Text));
                }
            }

        }
    }
}