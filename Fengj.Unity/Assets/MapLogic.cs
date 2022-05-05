using Fengj.Maps;
using Maths.Hex;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLogic : MonoBehaviour
{

    public Camera mapCamera;
    public Tilemap tilemapTerran;
    public Tilemap tileRivers;
    public Tilemap tileMask;

    public Tile tile;

    public static Dictionary<Terran, Color> dictTerranColor = new Dictionary<Terran, Color>()
    {
        { Terran.Plain, Color.green },
        { Terran.Hill, Color.yellow },
        { Terran.Water, Color.blue },
        { Terran.Mount, new Color(128/255f, 0, 128/255f) },
        { Terran.Marsh, new Color(95/255f, 158/255f, 160/255f) },
    };

    public static Dictionary<ViewType, Color> dictMaskColor = new Dictionary<ViewType, Color>()
    {
        { ViewType.Masked, new Color(0,0,0,1) },
        { ViewType.Fog, new Color(0,0,0,0.5f) },
        { ViewType.Clean, new Color(0,0,0,0) },
    };

    // Start is called before the first frame update
    void Start()
    {
        mapCamera.orthographicSize = 50;


        foreach (var cell in Global.session.map.terranCells)
        {
            var hexCoord = cell.offsetCoordinate.ToHexCoordinate();

            tilemapTerran.SetTile(hexCoord, tile);
            tilemapTerran.SetTileFlags(hexCoord, TileFlags.None);
            tilemapTerran.SetColor(hexCoord, dictTerranColor[cell.terran]);

            tileMask.SetTile(hexCoord, tile);
            tileMask.SetTileFlags(hexCoord, TileFlags.None);
            tileMask.SetColor(hexCoord, dictMaskColor[cell.viewType]);
        }

        foreach (var river in Global.session.map.riverCells)
        {
            var hexCoord = river.offsetCoordinate.ToHexCoordinate();
            tileRivers.SetTile(hexCoord, tile);
            tileRivers.SetTileFlags(hexCoord, TileFlags.None);

            tileRivers.SetColor(hexCoord, dictTerranColor[Terran.Water]);
        }
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = tilemapTerran.WorldToCell(mousePos);


            //if (tilemap.HasTile(gridPos))
            Debug.Log("Hello World from " + gridPos);
        }

        //当鼠标在屏幕边界，移动地图
        var offsetPos = mapCamera.ScreenToViewportPoint(Input.mousePosition);
        if (offsetPos.x < 0.01 || offsetPos.y < 0.01 || offsetPos.x >= 0.99f || offsetPos.y >= 0.99f)
        {
            if (offsetPos.x < 0 || offsetPos.y < 0)
            {
                return;
            }

            Vector3 move = (offsetPos - new Vector3(0.5f, 0.5f)) * 0.1f;

            mapCamera.transform.position += move;

        }

        //当鼠标滚轮转动,放大缩小地图
        var scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0)
        {
            mapCamera.orthographicSize -= scrollWheel;
        }
    }
}
