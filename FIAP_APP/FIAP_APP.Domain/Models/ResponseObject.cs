using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP_APP.Domain.Models
{
    public class ResponseObject
    {
       
        public static ResponseObject CreateResponseObject(int returnCode, string returnMessage)
        {
            return new ResponseObject()
            {
                code = returnCode,
                message = returnMessage,
            };
        }


        public int code { get; set; }

        public string message { get; set; }
    }
}
