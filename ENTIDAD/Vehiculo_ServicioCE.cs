using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Vehiculo_ServicioCE
    {
        [Key]
        public int ID_Vehiculo_Servicio { get; set; }
        public int ID_Servicio { get; set; }
        public int ID_Vehiculo { get; set; }
    }
}
