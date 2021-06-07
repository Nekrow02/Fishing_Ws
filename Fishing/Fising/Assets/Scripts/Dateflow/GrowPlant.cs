using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrowPlant : MonoBehaviour
{
    public Grid grid;
    public Tilemap tile;
    public TileBase test;
    public Sprite spt;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
           tile.SetTile(Vector3Int.FloorToInt(tile.CellToLocal(Vector3Int.FloorToInt(transform.localPosition * 6.25f))),test);
    }
}
