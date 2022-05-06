﻿using Fengj.GSessions;
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

            seed = "TEST1"
        };

        Global.session = new GSession(initData);

        SceneManager.LoadSceneAsync(nameof(MainScene), LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {

    }
}