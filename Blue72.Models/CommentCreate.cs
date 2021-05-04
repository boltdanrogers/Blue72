using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue72.Models
{   // Limits anount of text user can enter into comment area
    public class CommentCreate
    {
        [MaxLength(8000)]
        public string Text { get; set; }
    }
}
