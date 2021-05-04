﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue72.Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(2, ErrorMessage ="Please enter at least two characters.")]
        [MaxLength(100, ErrorMessage ="There are too many characters.")]
        public string Title { get; set; }
        [MaxLength(8000)]
        public string Text { get; set; }

    }//end of class PostCreate
}
