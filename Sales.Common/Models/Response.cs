using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Common.Models
{
    //Clase que devuelve el servicio API REST FULL
    public class Response
    {
        //si fue exitosa la comunicacion o no
        public bool IsSuccess { get; set; }

        //en caso de no ser exitosa tenemos el mensage, que sera el mensage de error
        public string Message { get; set; }

        //en caso de ser exitosa tenemos el resultado
        public object Result { get; set; }
    }
}
