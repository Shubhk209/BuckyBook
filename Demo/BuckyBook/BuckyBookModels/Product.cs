using BuckyBookWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuckyBookModels
{
	public class Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public string ISBN { get; set; }
		[Required]
		public string Author { get; set; }
		[Required]
		[Range(1,10000)]
		public double ListPrice { get; set; }
		[Required]
		[Range(1, 10000)]
		public string Price { get; set; }

        public string ImageUrl { get; set; }
		
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public int CoverTypeId { get; set; }
		public CoverType CoverType { get; set; }

    }
}
