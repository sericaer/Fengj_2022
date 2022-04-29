using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maths.Hex;

namespace Fengj.Maps
{
    public static class MapBuilder
    {
        public static Map Build(MapInit mapInit)
        {
            var axialCoords = HexBuilder.Build(mapInit.size).ToArray();
            var dictLandForm = LandFormBuilder.Build(axialCoords, mapInit.landFormPercent);

            var map = new Map();
            map.cells.AddRange(dictLandForm.Select(pair => new Cell(pair.Key, pair.Value)));

            return map;
        }
    }
}
