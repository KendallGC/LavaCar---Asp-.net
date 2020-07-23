using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD

{
   public  class ServiciosCE
    {
        [Key]
        public int ID_Servicio { get; set; }
        public string Descripcion { get; set; }
        public int Monto { get; set; }


    }
}
