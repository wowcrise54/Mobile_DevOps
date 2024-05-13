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
	public partial class review : ContentPage
	{
        private const int TotalStars = 5;
        public review ()
		{
			InitializeComponent ();
            InitializeStars();
        }
        private void InitializeStars()
        {
            for (int i = 0; i < TotalStars; i++)
            {
                var starImage = new Image
                {
                    Source = "star4.png", // Начальное изображение пустой звезды
                    WidthRequest = 43,
                    HeightRequest = 43
                };

                // Создаем локальную переменную для передачи в обработчик
                int currentIndex = i;
                var tapGesture = new TapGestureRecognizer();
                tapGesture.Tapped += (s, e) => StarTapped(currentIndex);
                starImage.GestureRecognizers.Add(tapGesture);

                starsLayout.Children.Add(starImage);
            }
        }

        private void StarTapped(int index)
        {
            // Обновляем изображения звезд
            for (int i = 0; i <= index; i++) // Закрашиваем звезды до включительно нажатой
            {
                var image = (Image)starsLayout.Children[i];
                image.Source = "star3.png"; // Заполняем звезду
            }

            for (int i = index + 1; i < TotalStars; i++) // Очищаем звезды после нажатой
            {
                var image = (Image)starsLayout.Children[i];
                image.Source = "star4.png"; // Оставляем звезду пустой
            }
        }
        private void OnImageTapped(object sender, EventArgs e)
        {
            Image tappedImage = sender as Image;

            // Примеры новых источников картинок, здесь нужно ваше определение
            Image1.Source = tappedImage == Image1 ? "like_1.png" : "like1_dark.png";
            Image2.Source = tappedImage == Image2 ? "like_2.png" : "like2_dark.png";
            Image3.Source = tappedImage == Image3 ? "like_3.png" : "like3_dark.png";
            Image4.Source = tappedImage == Image4 ? "like_4.png" : "like4_dark.png";
            Image5.Source = tappedImage == Image5 ? "like_5.png" : "like5_dark.png";
        }




    }
}