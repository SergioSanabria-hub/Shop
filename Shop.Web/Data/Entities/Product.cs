using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data.Entities
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class Product
	{
		public int Id { get; set; }

		[Display(Name = "Nombre")]
		[MaxLength(50, ErrorMessage = "El nombre no puede ser mayor a 50 caracteres")]
		[Required]
		public string Name { get; set; }

		[Display(Name = "Precio")]
		[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
		public decimal Price { get; set; }

		[Display(Name = "Imagen")]
		public string ImageUrl { get; set; }

		[Display(Name = "Ult. Compra")]
		public DateTime? LastPurchase { get; set; }

		[Display(Name = "Ult. Venta")]
		public DateTime? LastSale { get; set; }

		[Display(Name = "Disponible?")]
		public bool IsAvailabe { get; set; }

		[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
		public double Stock { get; set; }
	}

}
