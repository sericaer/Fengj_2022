using Maths.Hex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Extentions
{
    public static Vector3Int ToHexCoordinate(this OffsetCoordinate coord)
    {
        return new Vector3Int(coord.row * -1, coord.col, 0);
    }
}