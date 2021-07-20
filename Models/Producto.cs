using System;
using System.Collections.Generic;

#nullable disable

namespace WSVentas_3.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Conceptos = new HashSet<Concepto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Preciounitario { get; set; }
        public decimal Costo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public virtual ICollection<Concepto> Conceptos { get; set; }
    }
}
