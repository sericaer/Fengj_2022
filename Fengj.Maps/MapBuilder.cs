using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maths.Hex;
using Fengj.Logs;

namespace Fengj.Maps
{
    public static class MapBuilder
    {
        public static Map Build(MapInit mapInit, string seed)
        {
            var rivers = RiverBuilder.Build(mapInit.size, new GRandom(seed));
            var dictLandForm = LandFormBuilder.Build(mapInit, rivers, new GRandom(seed));

            var map = new Map();
            map.terranCells.AddRange(dictLandForm.Select(pair => new TerranCell(pair.Key, pair.Value)));
            map.riverCells.AddRange(rivers);

            Logger.Info($"landform count {map.terranCells.Count()}: {string.Join(" ", Enum.GetValues(typeof(Terran)).OfType<Terran>().Select(e => $"({e}, {map.terranCells.Count(cell => cell.terran == e)})"))}");

            return map;
        }
    }
}
