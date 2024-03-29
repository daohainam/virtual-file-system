﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualFileSystem.Abstractions
{
    public interface IVObject
    {
        string Name { get; }
        string FullName { get; }
        bool Exists { get; }
    }
}
