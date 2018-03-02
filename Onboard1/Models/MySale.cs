using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Onboard1.Models
{
    public class MySale
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string StoreName { get; set; }
        public DateTime DateSold { get; set; }
    }
}