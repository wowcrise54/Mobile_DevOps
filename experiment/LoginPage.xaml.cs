using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace experiment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private AuthService _authService = new AuthService();

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var mail = MailEntry.Text;
            var password = PasswordEntry.Text;

            var token = await _authService.Login(mail, password);
            if (token != null)
            {
                await DisplayAlert("Success", "Login successful", "OK");
                // Можно добавить переход на другую страницу после успешного входа
                await Navigation.PushAsync(new Home());
            }
            else
            {
                await DisplayAlert("Error", "Login failed", "OK");
            }
        }

        private async void OnMainPage(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
