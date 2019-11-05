using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TecReview.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreated { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string HomeImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public bool IsShowMap { get; set; }

        public List<Comment> Comments { get; set; }
    }
}