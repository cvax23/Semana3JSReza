using Semana3JSReza.Entities;
using System;
using Xamarin.Forms;

namespace Semana3JSReza
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (txtUser.Text.Equals(string.Empty) || 
                txtPassword.Text.Equals(string.Empty))
            {
                await DisplayAlert("Alert", "Please insert all fields", "Ok");
                return;
            }

            User user = new User
            {
                UserName = txtUser.Text,
                Password = txtPassword.Text
            };

            if (txtUser.Text.Equals("estudiante2020") &&
                txtPassword.Text.Equals("uisrael2020"))
            {
                await Navigation.PushAsync(new GradesProcessor(user));
            }
            else
            {
                await DisplayAlert("Alert", "User or password incorrect", "Ok");
                txtUser.Text = txtPassword.Text = string.Empty;
            }
            
        }
    }
}
