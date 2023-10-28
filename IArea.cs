﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle3
{
    public interface IArea
    {
        string Name { get; }    
        double Area();
    }

    public interface IPrototype<T> 
    {
        T Clone();
    }
}
