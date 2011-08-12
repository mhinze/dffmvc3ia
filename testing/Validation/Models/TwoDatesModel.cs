using System;
using System.ComponentModel.DataAnnotations;

namespace Validation.Models
{
    public class TwoDatesModel
    {
        [Required]
        public DateTime? Earlier { get; set; }

        [Required]
        [DateComesLater("Earlier")]
        public DateTime? Later { get; set; }
    }
}