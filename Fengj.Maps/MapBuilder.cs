using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maths.Hex;

namespace Fengj.Maps
{
    public static class MapBuilder
    {
        public static Map Build(int size)
        {
            var axialCoords = HexBuilder.Build(size);

            var map = new Map();
            map.cells.AddRange(axialCoords.Select(x => new Cell(x)));

            return map;
        }
    }
}
