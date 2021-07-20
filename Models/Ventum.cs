using System;
using System.Collections.Generic;

#nullable disable

namespace WSVentas_3.Models
{
    public partial class Ventum
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Concepto Concepto { get; set; }
    }
}
