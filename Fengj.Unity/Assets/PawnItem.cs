using Fengj.Clans;
using Maths.Hex;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PawnItem : MonoBehaviour
{
    public Tilemap tilemap;

    public Text label;
    private Clan _clan;

    public Clan clan
    {
        get
        {
            return _clan;
        }
        set
        {
            _clan = value;
            this.gameObject.SetActive(_clan != null);
        }
    }

    private void Start()
    {
        if(clan == null)
        {
            this.gameObject.SetActive(false);
            return;
        }

        FixedUpdate();
    }

    private void FixedUpdate()
    {
        label.text = clan.name;
        gameObject.transform.position = tilemap.CellToWorld(clan.coordnate.ToOffset().ToHexCoordinate());
    }
}
