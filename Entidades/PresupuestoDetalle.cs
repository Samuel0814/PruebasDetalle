using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class PresupuestosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int PresupuestoId { get; set; }
        public int TipoEgresoId { get; set; }

        [ForeignKey("TipoEgresoId")]
        //Permite indicar por cual campo se usara
        //la NAVIGATION PROPERTY
        public virtual TiposEgresos TipoEgreso { get; set; }

        public decimal Monto { get; set; }

        public PresupuestosDetalle()
        {
            this.Id = 0;
            this.PresupuestoId = 0;
            this.Monto = 0;
        }

        public PresupuestosDetalle(int id, int presupuestoId, int tipoEgresoId, decimal monto)
        {
            this.Id = id;
            this.PresupuestoId = presupuestoId;
            this.TipoEgresoId = tipoEgresoId;
            this.Monto = monto;
        }
    }
}
