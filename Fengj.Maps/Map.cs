﻿using System;
using System.Collections.Generic;

namespace Fengj.Maps
{
    public class Map
    {
        public static Map inst;

        public List<Cell> cells = new List<Cell>();
    }

    public class MapInit
    {
        public int size;
        public Dictionary<LandForm, int> landFormPercent;
    }
}
