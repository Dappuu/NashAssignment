using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SubCatgegory
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<SubCategoryDto>? SubCategories { get; set; }
    }
}
