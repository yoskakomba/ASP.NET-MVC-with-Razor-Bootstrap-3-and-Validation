using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Onboard1.Models
{
    public class MyStore
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input store name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input store Address")]
        public string Address { get; set; }
    }
}