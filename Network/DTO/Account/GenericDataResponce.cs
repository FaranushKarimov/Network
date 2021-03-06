using System;
using System.Collections.Generic;
using System.Text;

namespace Network.DTO.Account
{
    public class GenericDataResponce<T>
    {
        public bool Succeded { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
