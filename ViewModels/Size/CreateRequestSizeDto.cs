using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Size
{
    public class CreateRequestSizeDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
