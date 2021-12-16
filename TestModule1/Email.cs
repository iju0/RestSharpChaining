using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Email : IEmail
    {
        [Required(AllowEmptyStrings = true)]
        public string Title { get; set; }
        public string Content { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
    }
}
