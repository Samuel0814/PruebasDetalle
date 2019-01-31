using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class TiposEgresos
    {
        [Key]
        public int TipoEgresoId { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        public decimal Acumulado { get; set; }
        public bool EsActivo { get; set; }

        public TiposEgresos()
        {
            TipoEgresoId = 0;
            Descripcion = string.Empty;
            Acumulado = 0;
            EsActivo = true;
        }
    }
}
