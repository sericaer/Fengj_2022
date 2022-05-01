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
            landFormPercent = new Dictionary<LandForm, int>()
            {
                { LandForm.Water, 10 },
                { LandForm.Hill, 10 }
            }
        };

        Global.session = new GSession(mapInit);

        Debug.Log($"landform count {Global.session.map.cells.Count()}: {string.Join(" ", Enum.GetValues(typeof(LandForm)).OfType<LandForm>().Select(e=>$"({e}, {Global.session.map.cells.Count(cell => cell.landForm == e)})"))}");

        SceneManager.LoadSceneAsync(nameof(MainScene), LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {

    }
}