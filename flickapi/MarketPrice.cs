using System;

namespace flickapi
{
    public class MarketPrice
    {

        public string kind { get; set; }
        public string customer_state { get; set; }
        public Needle needle { get; set; }


        public class Needle
        {
            public string price { get; set; }
            public string status { get; set; }
            public string unit_code { get; set; }
            public string per { get; set; }
            public DateTime start_at { get; set; }
            public DateTime end_at { get; set; }
            public DateTime now { get; set; }
            public string type { get; set; }
            public string[] charge_methods { get; set; }
            public Component[] components { get; set; }
        }

        public class Component
        {
            public string charge_method { get; set; }
            public string value { get; set; }
        }

    }
}
