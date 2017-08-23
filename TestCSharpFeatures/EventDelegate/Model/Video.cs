﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventDelegate.Interfaces;

namespace EventDelegate.Model
{
    public class Video : IFile
    {
        public string Title { get; set; }
        public void Encode()
        {
            Console.WriteLine("VIDEO : 0000-1111-2222-3333-4444-5555-6666-7777-8888-9999");
        }
    }
}