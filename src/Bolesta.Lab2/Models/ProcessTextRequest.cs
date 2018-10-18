using System.ComponentModel.DataAnnotations;

namespace Bolesta.Lab2.Models
{
    public class ProcessTextRequest
    {
        [Required]
        public string Text { get; set; }
    }
}
