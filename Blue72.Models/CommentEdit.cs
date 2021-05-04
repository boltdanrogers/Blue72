using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue72.Models
{
    public class CommentEdit
    {
        public int CommentId { get; set; } // Needed for a specific comment
        public string Text { get; set; } // That text of the comment that will be changed
    }
}

