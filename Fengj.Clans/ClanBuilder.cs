using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Clans
{
    public class ClanBuilder
    {
        public static List<Clan> Build(ClanInit clan, string seed)
        {
            var list = new List<Clan>();

            foreach(var elem in clan.elements)
            {
                list.Add(new Clan(elem));
            }

            return list;
        }
    }
}
