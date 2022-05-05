using Fengj.Maps;
using Maths.Hex;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLogic : MonoBehaviour
{
    public Tilemap tilemap;
    public Tilemap tileRivers;

    public Tile tile;

    public static Dictionary<LandForm, Color> dictColor = new Dictionary<LandForm, Color>()
    {
        { LandForm.Plain, Color.green },
        { LandForm.Hill, Color.yellow },
        { LandForm.Water, Color.blue },
        { LandForm.Mount, new Color(128/255f, 0, 128/255f) },
        { LandForm.Marsh, new Color(95/255f, 158/255f, 160/255f) },
    };

    // Start is called before the first frame update
    void Start()
    {
        tilemap.ClearAllTiles();

        foreach (var cell in Global.session.map.cells)
        {
            var hexCoord = cell.offsetCoordinate.ToHexCoordinate();
            tilemap.SetTile(hexCoord, tile);
            tilemap.SetTileFlags(hexCoord, TileFlags.None);

            tilemap.SetColor(hexCoord, dictColor[cell.landForm]);
        }

        foreach (var river in Global.session.map.rivers)
        {
            var hexCoord = river.offsetCoordinate.ToHexCoordinate();
            tileRivers.SetTile(hexCoord, tile);
            tileRivers.SetTileFlags(hexCoord, TileFlags.None);

            tileRivers.SetColor(hexCoord, dictColor[LandForm.Water]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = tilemap.WorldToCell(mousePos);

            
            //if (tilemap.HasTile(gridPos))
            Debug.Log("Hello World from " + gridPos);
        }
    }
}
