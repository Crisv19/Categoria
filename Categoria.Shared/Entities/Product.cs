using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categoria.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Producto")] //{0}
        [MaxLength(100, ErrorMessage = "El nombre del {0} solo es hasta {1} caracteres")]
        [Required(ErrorMessage = "*El campo {0} es obligatorio")]
        public String Name { get; set; } = null;



    }
}
