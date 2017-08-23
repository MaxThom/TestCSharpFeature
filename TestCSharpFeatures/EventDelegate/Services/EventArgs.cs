using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate.Services
{
    public class EventArgs<T> : EventArgs
    {
        public T Data { get; set; }
    }
}
