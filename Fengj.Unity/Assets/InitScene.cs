using Fengj.GSessions;
using Fengj.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var mapInit = new MapInit()
        {
            size = 50,

            landFormPercent = new Dictionary<Terran, int>()
            {
                { Terran.Water, 7 },
                { Terran.Marsh, 2 },
                { Terran.Hill, 10 },
                { Terran.Mount, 1 },
            }
        };

        Global.session = new GSession(mapInit);

        Debug.Log($"landform count {Global.session.map.terranCells.Count()}: {string.Join(" ", Enum.GetValues(typeof(Terran)).OfType<Terran>().Select(e=>$"({e}, {Global.session.map.terranCells.Count(cell => cell.terran == e)})"))}");

        SceneManager.LoadSceneAsync(nameof(MainScene), LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {

    }
}