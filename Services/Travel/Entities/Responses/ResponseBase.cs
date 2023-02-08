using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Responses
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
            ResponseTime = DateTime.UtcNow;
            Message = "";
        }
        /// <summary>
        /// hora que la API retorna la respuesta
        /// </summary>
        public DateTime ResponseTime { get; set; }
        /// <summary>
        /// Mensaje de respuesta 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// Codigo del error 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// datos de respuesta 
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// total de registros en listas
        /// </summary>
        public int Count { get; set; }
    }
}
