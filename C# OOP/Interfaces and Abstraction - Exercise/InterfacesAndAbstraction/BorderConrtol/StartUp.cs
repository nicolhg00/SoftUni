﻿using BorderControl.Contracts;
using BorderControl.Core;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Run();
        }
    }
}
