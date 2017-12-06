using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class data_return_car
    {
        public List<Item> items { get; set; }
        public Category category_eachitem { get; set; }
    }
    public class data_return_index
    {
        public IEnumerable<User> users { get; set; }
        public IEnumerable<news> news { get; set; }
    }
}