﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue72.Models
{
    public class ReplyListItem
    {
        public int ReplyId { get; set; }
        public string Text { get; set; } 
        public int CommentID { get; set; }
    }
}
