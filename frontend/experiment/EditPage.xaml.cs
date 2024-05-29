using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static experiment.ProfilePage;
using System.Security;

namespace experiment
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPage : ContentPage
	{
        public class Profile
        {
            public string Name { get; set; }
            public string Mail { get; set; }
            public string Pass {  get; set; }
        }
        public EditPage ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
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
            using (HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://192.168.0.102:5000")
            })
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt_token);
                    HttpResponseMessage response = await client.GetAsync("/profile/edit");
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Profile profile = JsonConvert.DeserializeObject<Profile>(content);
                        NameEntry.Text = profile.Name;
                        EmailEntry.Text = profile.Mail;
                        PassEntry.Text = profile.Pass;
                    }
                }
                catch (Exception e)
                {
                    await DisplayAlert("Error", "Что-то пошло не так", "OK");
                }
            }
        }
        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
            var name = NameEntry.Text;
            var mail = EmailEntry.Text;
            var pass = PassEntry.Text;

            using (HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://192.168.0.102:5000")
            })
            {
                try
                {
                    var jwt_token = Preferences.Get("jwt_token", "");
                    var data =  new { name, pass, mail };
                    var json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt_token);
                    var response = await client.PostAsync("/profile/edit", content);

                    if (response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Success", "UserProfile has been edited", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Error", pass, "OK");
                    }
                    
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Something went wrong", "OK");
                }
            }
        }
    }
}