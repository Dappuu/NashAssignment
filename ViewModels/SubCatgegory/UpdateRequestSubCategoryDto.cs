﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SubCatgegory
{
    public class UpdateRequestSubCategoryDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int? ParentId { get; set; }
    }
}
