﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Triangle3.Figures
{
    [DisplayName("Kwadrat")]
    public class Square : AClassNameAttribute<Square>, IArea, IPrototype<Square>
    {
        private string Uuid { get; set; }
        [DisplayName("Bok")]
        public double Side { get; private set; }
        public string Name { get; private set; }
       
        public Square(double a)
            :base()
        {
            Uuid = base.Uuid;
            Side = a;
            var propertiesName = base.GetDescription<Square>();
            Name = $"{Uuid} {base.GetDisplayName<Square>()} ({propertiesName[0]}: {Side})";
        }

        public double Area()
        {
            return Side * Side;
        }

        public override string ToString()
        {
            return $"{nameof(Square)} (SideA: {Side})";
        }

        public Square Clone()
        {
            return new Square(Side);
        }
    }
}
