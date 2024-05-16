using System;
using System.Collections.Generic;
using System.Text;

namespace experiment
{
    //классы данных
    public class Ingredient
    {
        public string Name { get; set; }
        public string Amount { get; set; }
    }

    public class Step
    {
        public int Number { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
    }

    public class KabachokItem
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }

        public KabachokItem()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }
    }

    //public class Revieww
    //{
    //    public string Author { get; set; }
    //    public string Content { get; set; }
    //    public int Rating { get; set; }
    //}
}
