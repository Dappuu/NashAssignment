using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Image
{
	public class ImageDto
	{
		public int Id { get; set; }
		public required string Url { get; set; }
	}
}
