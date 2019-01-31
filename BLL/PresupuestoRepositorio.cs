using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BLL
{
    public class PresupuestoRepositorio : RepositorioBase<Presupuestos>
    {
        public override Presupuestos Buscar(int id)
        {
            Presupuestos presupuesto = new Presupuestos();
            try
            {
                presupuesto = _contexto.Presupuestos.Find(id);

                presupuesto.Detalle.Count();//Cargar la lista en este punto porque         //luego de hacer Dispose() el Contexto           //no sera posible leer la lista

                foreach (var item in presupuesto.Detalle)//Cargar los nombres de las ciudades            
                { string s = item.TipoEgreso.Descripcion; } //forzando la ciudad a cargarse

            }
            catch (Exception)
            {

                throw;
            }
            return presupuesto;
        }

        public override bool Modificar(Presupuestos presupuesto)
        {
            bool paso = false;
            try
            {
                //buscar las entidades que no estan para removerlas
                var Anterior = _contexto.Presupuestos.Find(presupuesto.PresupuestoId);
                foreach (var item in Anterior.Detalle)
                {
                    if (!presupuesto.Detalle.Exists(d => d.Id == item.Id))
                    {
                        item.TipoEgreso = null;
                        _contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                //recorrer el detalle
                foreach (var item in presupuesto.Detalle)
                {
                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    _contexto.Entry(item).State = estado;
                }

                //Idicar que se esta modificando el encabezado
                _contexto.Entry(presupuesto).State = EntityState.Modified;

                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
    }
}
