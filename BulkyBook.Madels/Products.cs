﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class Product
    {
        public int Id { get; set; }
        [ValidateNever]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 1000)]
        [Display(Name ="List Price")]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 1000)]
        [Display(Name ="Price 1 - 100")]
        public double Price { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name ="Price for 51 - 100 ")]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 1000)]
        [Display(Name ="Price for 100 +")]
        public double Price100 { get; set; }
        [ValidateNever]
        [Display(Name ="Image URL ")]
        public string ImageUrl { get; set; }

        [Display(Name ="Category Type")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Display(Name ="Cover Type")]
        public int CoverTypeId { get; set; }
        [ValidateNever]
        public CoverType CoverType { get; set; }
    }
}