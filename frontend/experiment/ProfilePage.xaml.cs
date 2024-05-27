using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Newtonsoft.Json.Linq;
using System.Xml;

namespace experiment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {   
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Получаем информацию о профиле пользователя при загрузке страницы
            await LoadUserProfile();
        }
        private async Task LoadUserProfile()
        {
            var jwt_token = Preferences.Get("jwt_token", "");
            if (string.IsNullOrEmpty(jwt_token))
            {
                await DisplayAlert("Error", "jwt токен пустой", "OK");
                return;
            }
            using (HttpClient client = new HttpClient {
                BaseAddress = new Uri("http://172.30.74.244:5000")
            })
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt_token);
                    HttpResponseMessage response = await client.GetAsync("/profile/me");
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Profile profile = JsonConvert.DeserializeObject<Profile>(content);
                        NameLabel.Text = profile.Name;
                        EmailLabel.Text = profile.Mail;
                    }
                }
                catch (Exception e) {
                    await DisplayAlert("Error", "Что-то пошло не так", "OK");
                }
            }
        }
        public class Profile
        {
            public string Name { get; set; }
            public string Mail { get; set; }
        }


        private async void OnFeedBack(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
        private async void OnMyRecipes(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new myrecipes());
        }
        private async void OnUsers(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserAgreement());
        }
        private async void OnPolitica(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Politica());
        }

        private async void OnStartPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartPage());
        }

        private async void EditPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPage());
        }
    }
}