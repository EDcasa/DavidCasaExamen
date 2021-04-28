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
    public partial class Login : ContentPage
    {
        public Login()
        {

            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String clave= txtClave.Text;
            if (usuario == "estudiante2021")
            {
                if (clave == "uisrael2021") {
                    await Navigation.PushAsync(new Registro(usuario));
                }
                else
                {
                    DisplayAlert("Verificar información", "La clave es incorrecta", "Aceptar");
                }
            }
            else
            {
                DisplayAlert("Verificar información", "El usuario es incorrecto", "Aceptar");
            }
        }
    }
}