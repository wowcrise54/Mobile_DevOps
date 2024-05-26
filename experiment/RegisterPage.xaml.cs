using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace experiment
{
    public partial class RegisterPage : ContentPage
    {
        private AuthService _authService = new AuthService();

        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var name = NameEntry.Text;
            var mail = MailEntry.Text;
            var password = PasswordEntry.Text;

            var success = await _authService.Register(name, mail, password);
            if (success)
            {
                await DisplayAlert("Success", "User registered successfully", "OK");
                // Можно добавить переход на другую страницу после успешной регистрации
            }
            else
            {
                await DisplayAlert("Error", "Registration failed", "OK");
            }
        }


        private async void OnMainPage(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}