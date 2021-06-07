using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{
    private Vector3 center;
    private BoxCollider2D col;

    private float date;
    public TileBase dirt;
    public Tilemap tile;
    private TileBase[] map;



    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.AddComponent<BoxCollider2D>();
        col.size = new Vector3(0.05f, 0.05f);
        col.offset = new Vector3(0.05f, 0.05f);

        center = col.bounds.center;
        tile.SetTile(Vector3Int.FloorToInt(tile.CellToLocal(Vector3Int.FloorToInt(center * 10))), dirt);

        GetTile(null);
    }

    public void ValueForGrow()
    {
        tile.SetTile(Vector3Int.FloorToInt(tile.CellToLocal(Vector3Int.FloorToInt(center * 10))), map[1]);
    }

    private void GetTile(TileBase[] tilebases)
    {
        if (tilebases == null)
        {
            tile.SetTile(Vector3Int.FloorToInt(tile.CellToLocal(Vector3Int.FloorToInt(center * 10))), dirt);
        }
        else
        {
            GetPlant(tilebases);
        }
    }

    public void SetTile(TileBase[] bases)
    {
        if (bases != null)
        {
            date = Mathf.FloorToInt(Global.date);

            GetTile(bases);
        }
    }
    private void GetPlant(TileBase[] tilebases)
    {
        map = tilebases;
        tile.SetTile(Vector3Int.FloorToInt(tile.CellToLocal(Vector3Int.FloorToInt(center * 10))), tilebases[0]);
    }
}