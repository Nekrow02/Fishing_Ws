using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrowPlant : MonoBehaviour
{
    public Transform grid;
    public Tilemap tile;
    public TileBase dirt;

    [SerializeField]
    private TileBase[] strowBerry;
    [SerializeField]
    private TileBase[] waterMellon;
    [SerializeField]
    private TileBase[] pumpkin;

    private List<TileBase[]> spt = new List<TileBase[]>();
    private Plant plant;
    private bool isPlant = false;
    public enum Equip : int { StrowBerry = 0, WaterMellon, Pumpkin };
    private Equip equip = new Equip();
    // Start is called before the first frame update
    void Start()
    {
        SetPlantArr();
    }

    private void SetPlantArr()
    {
        spt.Add(strowBerry);
        spt.Add(waterMellon);
        spt.Add(pumpkin);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GetComponent<Char_Move>().moving = true;
            if (!isPlant&& GetComponent<Char_Move>().moving == true)
            {
                GameObject seed = new GameObject("dig");
                seed.tag = "DIG";
                Plant p = seed.AddComponent<Plant>();
                seed.transform.position = transform.position;
                seed.transform.SetParent(tile.transform);

                p.tile = tile;
                p.dirt = dirt;
                p.name = "dirt";
            }
            else
            {
                if (plant != null && GetComponent<Char_Move>().moving == true)
                {
                    equip = Equip.StrowBerry;
                    plant.gameObject.name = "StrowBerry";
                    plant.SetTile(spt[(int)equip]);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("DIG"))
        {
            isPlant = true;
            plant = collision.GetComponent<Plant>();
        }
        if (collision.CompareTag("WATER"))
        {
            isPlant = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DIG"))
        {
            isPlant = false;
            plant = null;
        }
        if (collision.CompareTag("WATER"))
        {
            isPlant = false;
        }
    }
}
