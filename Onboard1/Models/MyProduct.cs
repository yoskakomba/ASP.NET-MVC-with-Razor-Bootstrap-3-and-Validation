using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Onboard1.Models
{
    public class MyProduct
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input product price")]
        public decimal Price { get; set; }

    }
}