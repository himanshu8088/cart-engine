using System;
using System.Collections.Generic;
using System.Text;

namespace CartEngine.Model
{
    public class Cart
    {
        public List<Item> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
