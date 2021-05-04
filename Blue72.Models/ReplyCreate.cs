using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue72.Models
{
    public class ReplyCreate
    {
        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }
        [Display(Name = "Comment Name")]
        public int CommentID { get; set; }
    }
}
