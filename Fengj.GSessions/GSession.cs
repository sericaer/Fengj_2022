using Fengj.Maps;
using System;
using Maths.Hex;

namespace Fengj.GSessions
{
    public class GSession
    {
        public Map map { get; set; }

        public GSession(SessionInitData initData)
        {
            map = MapBuilder.Build(initData.map, initData.seed);
        }
    }

    public class SessionInitData
    {
        public string seed;
        public MapInit map;
    }
}
