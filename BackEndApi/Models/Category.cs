﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; } = String.Empty;
		public int? ParentId { get; set; }
		public Category? Parent { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Category>? SubCategories { get; set; } 
		public List<Product>? Products { get; set; } 
	}
}
