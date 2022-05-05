using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MapCoordinates : MonoBehaviour
{
    public Tilemap tileMap;
    public Text defaultLabel;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var cell in Global.session.map.terranCells)
        {
            var worldPos = tileMap.CellToWorld(cell.offsetCoordinate.ToHexCoordinate());
            
            var newLabel = Instantiate(defaultLabel.gameObject, this.transform);
            newLabel.GetComponent<Text>().text = cell.offsetCoordinate.ToHexCoordinate().ToString();
            newLabel.transform.position = worldPos;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
