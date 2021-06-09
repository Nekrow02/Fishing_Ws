using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrowPlant : MonoBehaviour
{
    public Transform grid;
    public Tilemap tile;
    public TileBase[] dirt;

    [SerializeField]
    private TileBase[] strowBerry;
    [SerializeField]
    private TileBase[] waterMellon;
    [SerializeField]
    private TileBase[] pumpkin;
    [SerializeField]
    private S_GameManager manager;
    [SerializeField]
    private GameObject UI;
    private List<TileBase[]> spt = new List<TileBase[]>();
    private Plant plant;
    private bool isPlant = false;
    public enum Equip : int { StrowBerry = 0, WaterMellon, Pumpkin };
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
        if (Input.GetKeyDown(KeyCode.A))
        {

            if (!isPlant && GetComponent<Char_Move>().moving == true)
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
            if (isPlant && GetComponent<Char_Move>().moving == true &&
                plant != null && plant.name == "dirt"&& 
                !UI.gameObject.activeSelf)
            {
                UI.gameObject.SetActive(true);
            }
            else if (UI.gameObject.activeSelf)
            {
                UI.gameObject.SetActive(false);
            }
            if (plant != null)
            {
                if (isPlant && GetComponent<Char_Move>().moving == true)
                {
                    if (!plant.isWater)
                        plant.Water();
                    if (plant.harvestable)
                    {
                        Harvest();
                        manager.SetObjectCount();
                    }
                }
            }

        }
    }

    private void Harvest()
    {
        Inventory inven = manager.GetInventoryInManager();
        switch (plant.name)
        {
            case "StrowBerry":
                inven.ItemList["열매_딸기"]++;
                break;
            case "WaterMellon":
                inven.ItemList["열매_수박"]++;
                break;
            case "Pumpkin":
                inven.ItemList["열매_호박"]++;
                break;
        }
        Destroy(plant.gameObject);
    }

    public void SetTile(Equip eq)
    {
        switch (eq)
        {
            case Equip.StrowBerry: plant.harvesting = 2; break;
            case Equip.WaterMellon: plant.harvesting = 3; break;
            case Equip.Pumpkin: plant.harvesting = 3; break;
        }
        plant.gameObject.name = eq.ToString();
        plant.SetTile(spt[(int)eq]);
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
