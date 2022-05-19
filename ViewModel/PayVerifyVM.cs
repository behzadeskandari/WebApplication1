using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
    public class PayVerifyVM
    {

        [Required]
        public string Status { get; set; }

        [Required]
        public string Authority { get; set; }
    }
}
