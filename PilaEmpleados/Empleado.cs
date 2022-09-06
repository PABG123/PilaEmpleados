using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilaEmpleados
{
    public class Empleado
    {
        public string Identificacion { get; set;}
        public string Nombre { get; set;}
        public decimal SalarioDia { get; set;}
        public int DiasLaborados { get; set;}
        //public decimal Devengado { get { return SalarioDia * DiasLaborados;}}
        public decimal Devengado { get; set; }
        public DateTime Fecha { get; set;}


        public decimal CalcularDevengado (decimal salarioDia, int diasTrabajados)
        {
            Devengado = salarioDia * diasTrabajados;
            return Devengado;
        }      
            
            
      }
}
