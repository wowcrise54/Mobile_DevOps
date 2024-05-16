using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public ObservableCollection<Step> Steps { get; set; }

        public Kabachok()
        {
            InitializeComponent();
            // Привязка данных
            LoadData();
            BindingContext = this;

            //Revieww = new List<Revieww>
            //{
            //    new Revieww { Author = "Иван", Content = "Очень вкусно и просто!", Rating = 5 },
            //    new Revieww { Author = "Мария", Content = "Неплохо, но можно добавить больше специй.", Rating = 4 },
            //    new Revieww { Author = "Сергей", Content = "Мне не понравилось, слишком просто.", Rating = 2 }
            //};

        }

        private void LoadData()
        {
            Ingredients = new ObservableCollection<Ingredient>
            {
                new Ingredient { Name = "Первый", Amount = "100 гр" },
                new Ingredient { Name = "Второй", Amount = "100 гр" },
                new Ingredient { Name = "Третий", Amount = "100 гр" },
                new Ingredient { Name = "Четвертый", Amount = "100 гр" }
            };

            Steps = new ObservableCollection<Step>
            {
                new Step { Number = 1, Time = "05:00 мин", Description = "Описание шага 1..." },
                new Step { Number = 2, Time = "10:00 мин", Description = "Описание шага 2..." },
                new Step { Number = 3, Time = "15:00 мин", Description = "Описание шага 3..." }
            };
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
            //var image = KabachokData.TapCommand;
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