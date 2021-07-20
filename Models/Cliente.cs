using System;
using System.Collections.Generic;

#nullable disable

namespace WSVentas_3.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public virtual Ventum Ventum { get; set; }
    }
}
