using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLogic : MonoBehaviour
{
    public Tilemap tilemap;

    public Tile tile;

    // Start is called before the first frame update
    void Start()
    {
        tilemap.ClearAllTiles();

        foreach (var cell in Global.session.map.cells)
        {
            tilemap.SetTile(cell.offsetCoordinate.ToHexCoordinate(), tile);
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
