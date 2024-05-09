using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace experiment
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : TabbedPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            Application.Current.RequestedThemeChanged += OnThemeChanged;

        }
        protected override void OnDisappearing()
        {
            Application.Current.RequestedThemeChanged -= OnThemeChanged;
            base.OnDisappearing();
        }
        private void OnThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            ResetImagesToDefault();
        }

        private void ResetImagesToDefault()
        {
         
            foreach (var image in FindImages(this))
            {
                if (Application.Current.UserAppTheme == OSAppTheme.Dark ||
                    Application.Current.UserAppTheme == OSAppTheme.Unspecified && AppInfo.RequestedTheme == AppTheme.Dark)
                {
                    image.Source = "dark_not_like.png";
                }
                else
                {
                    image.Source = "light_not_like.png";
                }
            }
        }

        private IEnumerable<Image> FindImages(VisualElement parent)
        {
            if (parent is Image image)
            {
                yield return image;
            }
            else if (parent is Layout<View> layout)
            {
                foreach (var child in layout.Children)
                {
                    foreach (var childImage in FindImages(child))
                    {
                        yield return childImage;
                    }
                }
            }
        }
    }
}