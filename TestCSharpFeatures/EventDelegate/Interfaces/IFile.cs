using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate.Interfaces
{
    public interface IFile
    {
        string Title { get; set; }

        void Encode();
    }
}
