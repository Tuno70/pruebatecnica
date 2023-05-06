using CrudWindowsForm.Datos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWindowsForm.Dato
{
    public class DatosAdmin
    {
        public List<datos> Consultar () {
            using (CrudWFEntities contexto = new CrudWFEntities()) {
                return contexto.datos.AsNoTracking().ToList();            
            }
        }
        public void Guardar(datos datos)
        {
            using (CrudWFEntities contexto =new CrudWFEntities())
            {
                contexto.datos.Add(datos);
                contexto.SaveChanges();
            }
        }
    }
}
