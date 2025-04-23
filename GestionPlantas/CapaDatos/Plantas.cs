using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionPlantas.CapaDatos
{
    public class Plantas
    {
        public int Id { get; set; }             
        public string Nombre { get; set; }  
        public int CategoriaId { get; set; }
    }
}