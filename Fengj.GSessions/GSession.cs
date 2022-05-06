using Fengj.Maps;
using System;
using Maths.Hex;
using Fengj.Clans;
using System.Collections.Generic;

namespace Fengj.GSessions
{
    public class GSession
    {
        public Map map { get; set; }
        public IEnumerable<Clan> clans => _clans;

        private List<Clan> _clans = new List<Clan>();

        public GSession(SessionInitData initData)
        {
            map = MapBuilder.Build(initData.map, initData.seed);

            _clans = ClanBuilder.Build(initData.clan, initData.seed);
        }
    }

    public class SessionInitData
    {
        public string seed;

        public ClanInit clan;
        public MapInit map;
    }
}
