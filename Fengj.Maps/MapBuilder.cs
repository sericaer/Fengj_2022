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
            var rivers = RiverBuilder.Build(mapInit.size);
            var dictLandForm = LandFormBuilder.Build(mapInit, rivers);

            var map = new Map();
            map.terranCells.AddRange(dictLandForm.Select(pair => new TerranCell(pair.Key, pair.Value)));
            map.riverCells.AddRange(rivers);

            return map;
        }
    }
}
