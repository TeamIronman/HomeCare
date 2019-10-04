using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Utilities.Dtos
{
    public class GenericResult
    {

        public object Data { get; set; }

        public int Success { get; set; }

        public string Resultstring { get; set; }

        public string Message { get; set; }

        public object Error { get; set; }


        public GenericResult()
        {

        }

        public GenericResult(int success)
        {
            Success = success;
        }

        public GenericResult(string message)
        {
            Message = message;
        }

        public GenericResult(int success, string message)
        {
            Success = success;
            Message = message;
        }

        public GenericResult(int success, object data)
        {
            Success = success;
            Data = data;
        }


        public GenericResult(string resultstring, string message)
        {
            Resultstring = resultstring;
            Message = message;
        }
    }
}
