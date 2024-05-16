using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace experiment
{
    //класс данных
    public class LikeItem
    {
        public string ImageSource { get; set; }
        public string Title { get; set; }
        public Command TapCommand { get; set; }
    }
}
