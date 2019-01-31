using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Presupuestos
    {
        [Key]
        public int PresupuestoId { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }

        /*Lista tipo VisitasDetalle
        le colocamos virtual para usar el LazyLoading
        LazyLoading consiste en retrasar la carga de un objeto
        hasta el mismo momento de su utilización. */
        public virtual List<PresupuestosDetalle> Detalle { get; set; }

        public Presupuestos()
        {//Es obligatorio inicializar la lista
            this.Detalle = new List<PresupuestosDetalle>();
        }

        /// <summary>
        /// Este metodo permite agretar un item a la lista
        /// No es obligatorio, lo creo por comodidad
        /// </summary>
        public void AgregarDetalle(int id, int presupuestoId, int tipoEgresoId, decimal monto)
        {
            this.Detalle.Add(new PresupuestosDetalle(id, presupuestoId, tipoEgresoId, monto));
        }

        public void AgregarDetalle(int id, int presupuestoId, string tipoEgresoId, string monto)
        {
            decimal MontoConvertido = 0;
            decimal.TryParse(monto, out MontoConvertido);

            int tipoEgresoIdConvertido = 0;
            int.TryParse(tipoEgresoId, out tipoEgresoIdConvertido);

            this.AgregarDetalle(id, presupuestoId, tipoEgresoIdConvertido, MontoConvertido);
        }
    }
}
