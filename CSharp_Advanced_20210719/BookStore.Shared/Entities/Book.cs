using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Shared.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
