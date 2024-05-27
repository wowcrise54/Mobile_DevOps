using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace experiment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class like : ContentPage
    {
        public List<LikeItem> LikeItems { get; set; }

        public like()
        {
            InitializeComponent();
            LikeItems = new List<LikeItem>
            {
                new LikeItem
                {
                    ImageSource = "farsh.png",
                    Title = "Фаршированные кабачки",
                    TapCommand = new Command(async () => await Navigation.PushAsync(new Kabachok()))
                },
                new LikeItem
                {
                    ImageSource = "grudka.png",
                    Title = "Грудка на овощах",
                    TapCommand = new Command(async () => await Navigation.PushAsync(new Grudka()))
                },
                new LikeItem
                {
                    ImageSource = "chicken.png",
                    Title = "Запеченная курочка с овощами",
                    TapCommand = new Command(async () => await Navigation.PushAsync(new Chicken()))
                },
                new LikeItem
                {
                    ImageSource = "salat.png",
                    Title = "Салатик 'Высокая кухня'",
                    TapCommand = new Command(async () => await Navigation.PushAsync(new Salat()))
                }
            };

            BindingContext = this;
        }


        private async void ProfileButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        //private async void OnKabachok(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Kabachok());
        //}
        //private async void OnGrudka(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Grudka());
        //}
        //private async void OnChicken(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Chicken());
        //}
        //private async void OnSalat(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Salat());
        //}

        private void OnClick(object sender, EventArgs e)
        {
            var image = sender as Image;
            if (image == null) return;


            if (Application.Current.UserAppTheme == OSAppTheme.Dark)
            {
                if (image.Source.ToString().Contains("dark_not_like.png"))
                    image.Source = "dark_like.png";
                else
                    image.Source = "dark_not_like.png";
            }
            else
            {
                if (image.Source.ToString().Contains("dark_not_like.png"))
                    image.Source = "dark_like.png";
                else
                    image.Source = "dark_not_like.png";
            }
        }
    }
}