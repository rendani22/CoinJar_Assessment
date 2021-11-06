using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinJar.Models
{
    public partial class ResponseModel<T>
    {
        public ResponseModel(bool issuccessful = default(bool),string message = default(string),T result = default(T))
        {
            this.isSuccessful = issuccessful;
            this.Message = message;
            this.Result = result;
        }

        public bool isSuccessful { get; set; } = false;
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
