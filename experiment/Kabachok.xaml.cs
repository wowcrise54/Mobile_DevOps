using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace experiment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Kabachok : ContentPage
    {
        public Kabachok()
        {
            InitializeComponent();
        }

        private async void ProfileButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        private async void Review(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new review());
        }

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
                if (image.Source.ToString().Contains("light_not_like.png"))
                    image.Source = "light_like.png";
                else
                    image.Source = "light_not_like.png"; 
            }
        }
        private System.Timers.Timer _timer;
        private TimeSpan _timeLeft;

        private void OnTime(object sender, EventArgs e)
        {
            if (_timer != null && _timer.Enabled)
                return; // Если таймер уже запущен, пропускаем запуск нового

            // Разбираем текст для получения времени
            string timeText = timeLabel.Text.Replace(" мин", "");

            try
            {
                // Заменяем ':' на '.', чтобы соответствовать формату TimeSpan
                _timeLeft = TimeSpan.ParseExact(timeText, @"mm\:ss", CultureInfo.InvariantCulture);

                _timer = new System.Timers.Timer(1000); // Таймер с интервалом в 1 секунду
                _timer.Elapsed += OnTimerElapsed;
                _timer.Start();
            }
            catch (FormatException)
            {
                // Обработка ошибки при неправильном формате строки времени
                Debug.WriteLine("Неправильный формат времени");
            }
        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timeLeft = _timeLeft.Subtract(TimeSpan.FromSeconds(1));
            if (_timeLeft.TotalSeconds <= 0)
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
                Device.BeginInvokeOnMainThread(() =>
                {
                    timeLabel.Text = "00:00 мин";
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    timeLabel.Text = $"{_timeLeft:mm\\:ss} мин"; // Убедитесь, что формат соответствует вашему отображению
                });
            }
        }


    }
}