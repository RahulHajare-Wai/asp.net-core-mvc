using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class ShoppingCart
    {
        public Product product { get; set; }
        [Range(1,1000, ErrorMessage="Please Enter Value between 1-1000")]
        public int count { get; set; }
    }
}
