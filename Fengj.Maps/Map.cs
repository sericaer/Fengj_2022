using Maths.Hex;
using System;
using System.Collections.Generic;

namespace Fengj.Maps
{
    public class Map
    {
        public static Map inst;
        public static Action<TerranCell> onViewTypeChanged;

        public List<TerranCell> terranCells = new List<TerranCell>();
        public List<RiverCell> riverCells = new List<RiverCell>();
    }

    public class MapInit
    {
        public int size;
        public Dictionary<Terran, int> landFormPercent;
    }
}
