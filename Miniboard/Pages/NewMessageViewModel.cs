using System.ComponentModel.DataAnnotations;

namespace Miniboard.Pages
{
    public class NewMessageViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Message { get; set; }
    }
}