using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HookahCulture.Data.Models
{
    public class ChatMessage
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Message { get; set; }

        public string ProfilePicturePath { get; set; }

        public string FullName { get; set; }

        public string CreatedOn { get; set; }
    }
}
