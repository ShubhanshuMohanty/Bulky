using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models.ViewModels
{
    public class ProductDetailVM
    {
        [ValidateNever]
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; } = 1;
        [ValidateNever]
        public IEnumerable<Review> Reviews { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } = 1;
    }
}
