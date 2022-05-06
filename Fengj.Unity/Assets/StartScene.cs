using Fengj.GSessions;
using Fengj.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void OnNewGame()
    {
        SceneManager.LoadSceneAsync(nameof(InitScene), LoadSceneMode.Single);
    }

    public void OnMockGame()
    {
        var initData = new SessionInitData()
        {
            map = new MapInit()
            {
                size = 50,

                landFormPercent = new Dictionary<Terran, int>()
                {
                    { Terran.Water, 7 },
                    { Terran.Marsh, 2 },
                    { Terran.Hill, 10 },
                    { Terran.Mount, 1 },
                }
            },

            seed = DateTime.Now.ToString()
        };

        Global.session = new GSession(initData);

        SceneManager.LoadSceneAsync(nameof(MainScene), LoadSceneMode.Single);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}