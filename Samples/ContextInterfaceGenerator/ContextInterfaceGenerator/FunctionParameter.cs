﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContextInterfaceGenerator
{
    public class FunctionParameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool ByRef { get; set; }
    }
}
