using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PawnContainer : MonoBehaviour
{
    public Tilemap tileMap;
    public GameObject defaultPawn;

    // Start is called before the first frame update
    void Start()
    {
        FixedUpdate();
    }

    private void FixedUpdate()
    {
        var children = GetComponentsInChildren<PawnItem>();

        var needDels = children.Where(x => !Global.session.clans.Contains(x.clan)).ToArray();
        foreach(var elem in needDels)
        {
            Destroy(elem.gameObject);
        }

        var needAdds = Global.session.clans.Where(x => !children.Select(c => c.clan).Contains(x));
        foreach(var elem in needAdds)
        {
            var newInst = Instantiate(defaultPawn.gameObject, this.transform);
            newInst.GetComponent<PawnItem>().clan = elem;
        }
    }
}
