using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl
        {
            get
            {
                return string.Format("https://loremflickr.com/100/100?lock={0}", Id);
            }
        }
    }
}
