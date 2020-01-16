using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    public class Activity
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public string ImageUrl
        {
            get
            {
                return string.Format("https://loremflickr.com/100/100?lock={0}", UserId);
            }
        }
    }
}
