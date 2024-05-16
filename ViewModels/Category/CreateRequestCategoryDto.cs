using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Category
{
    public class CreateRequestCategoryDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
