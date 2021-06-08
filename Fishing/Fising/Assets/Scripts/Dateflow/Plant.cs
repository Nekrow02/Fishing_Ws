using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{
    private Vector3 center;
    private BoxCollider2D col;

    private float date = -1;
    public TileBase[] dirt;
    public Tilemap tile;
    private TileBase[] map;
    private TileBase startTile;

    public bool isWater = false;
    public bool harvestable = false;
    public float harvesting = 0;

    private void Update()
    {
        if(date != Global.date && date != -1)
        {
            date = Global.date-date;
            if(date == harvesting)
            {
                CheckHavesting();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.AddComponent<BoxCollider2D>();
        col.size = new Vector3(0.05f, 0.05f);
        col.offset = new Vector3(0.05f, 0.05f);

        center = col.bounds.center;
        startTile = tile.GetTile(Vector3Int.FloorToInt(tile.CellToLocal(Vector3Int.FloorToInt(center * 10))));
        tile.SetTile(Vector3Int.FloorToInt(tile.CellToLocal(Vector3Int.FloorToInt(center * 10))), dirt[0]);
    }

    private void CheckHavesting()
    {
        if (harvestable == false)
        {
            switch (name)
            {
                case "StrowBerry":
                    if (harvesting == 2)
                    {
                        GetPlant(map[2]);
                        harvesting = 4;
                    }

                    else if (harvesting == 4)
                    {
                        GetPlant(map[3]);
                        harvesting = 5;
                    }
                    else if (harvesting == 5)
                    {
                        harvestable = true;
                        date = -1;
                        GetPlant(map[4]);
                    }
                    break;

                case "WaterMellon":
                    if (harvesting == 3)
                    {
                        GetPlant(map[2]);
                        harvesting = 7;
                    }

                    else if (harvesting == 7)
                    {
                        GetPlant(map[3]);
                        harvesting = 9;
                    }

                    else if (harvesting == 9)
                    {
                        harvestable = true;
                        date = -1;
                        GetPlant(map[4]);
                    }
                    break;

                case "Pumpkin":
                    if (harvesting == 3)
                    {
                        GetPlant(map[2]);
                        harvesting = 7;
                    }
                    else if (harvesting == 7)
                    {
                        GetPlant(map[3]);
                        harvesting = 10;
                    }
                    else if (harvesting == 10)
                    {
                        harvestable = true;
                        date = -1;
                        GetPlant(map[4]);
                    }
                    break;
            }
        }
    }

    public void Water()
    {
        if (tile == null||map==null)
            return;
        date = Mathf.FloorToInt(Global.date);
        tile.SetTile(Vector3Int.FloorToInt(tile.CellToLocal(Vector3Int.FloorToInt(center * 10))), map[1]);
        isWater = true;
    }

    public void SetTile(TileBase[] bases)
    {
        if (bases != null)
        {
            map = bases;
            tile.SetTile(Vector3Int.FloorToInt(tile.CellToLocal(Vector3Int.FloorToInt(center * 10))), map[0]);
        }
    }

    private void GetPlant(TileBase tilebases)
    {
        tile.SetTile(Vector3Int.FloorToInt(tile.CellToLocal(Vector3Int.FloorToInt(center * 10))), tilebases);
    }
    private void OnDestroy()
    {
        tile.SetTile(Vector3Int.FloorToInt(tile.CellToLocal(Vector3Int.FloorToInt(center * 10))), startTile);
    }
}