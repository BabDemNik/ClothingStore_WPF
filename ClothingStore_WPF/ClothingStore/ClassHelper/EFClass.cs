﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingStore.DB;

namespace ClothingStore.ClassHelper
{
    public class EFClass
    {
        public static Entities Context { get; } = new Entities();
    }
}
