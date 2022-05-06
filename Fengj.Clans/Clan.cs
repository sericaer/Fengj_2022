using Maths.Hex;
using System;

namespace Fengj.Clans
{
    public class Clan
    {
        public Clan(ClanInit.Element initData)
        {
            this.name = initData.name;
            this.popNum = initData.popNum;
            this.coordnate = initData.coordnate;
        }

        public string name { get; set; }
        public decimal popNum { get; set; }

        public AxialCoordinate coordnate { get; set; }
    }

    public class ClanInit
    {
        public class Element
        {
            public string name;
            public int popNum;
            public AxialCoordinate coordnate;
        }

        public Element[] elements;
    }
}
