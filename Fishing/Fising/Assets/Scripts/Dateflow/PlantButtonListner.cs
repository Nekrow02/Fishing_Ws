using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantButtonListner : MonoBehaviour
{
    [SerializeField]
    private Button[] button;
    [SerializeField]
    private GrowPlant plant;
    [SerializeField]
    private S_GameManager manager;

    private void Start()
    {
        GrowPlant.Equip equip = new GrowPlant.Equip();
        GameObject parent = transform.parent.gameObject;

        Refresh();

        button[0].onClick.AddListener(() => 
        {
            parent = transform.parent.gameObject;
            Inventory inven = manager.GetInventoryInManager();
            if (inven.ItemList["씨앗_딸기"] > 0)
            {
                equip = GrowPlant.Equip.StrowBerry;
                plant.SetTile(equip);
                inven.ItemList["씨앗_딸기"]--;
                button[0].GetComponentInChildren<Text>().text = "X "+inven.ItemList["씨앗_딸기"].ToString();
                gameObject.SetActive(false);

            }
            else Debug.Log("부족함");
        });
        button[1].onClick.AddListener(() =>
        {
            parent = transform.parent.gameObject;
            Inventory inven = manager.GetInventoryInManager();
            if (inven.ItemList["씨앗_수박"] > 0)
            {
                equip = GrowPlant.Equip.WaterMellon;
                plant.SetTile(equip);
                inven.ItemList["씨앗_수박"]--;
                button[1].GetComponentInChildren<Text>().text = "X " + inven.ItemList["씨앗_수박"].ToString();
                gameObject.SetActive(false);
            }
            else Debug.Log("부족함");
        });
        button[2].onClick.AddListener(() =>
        {
            parent = transform.parent.gameObject;
            Inventory inven = manager.GetInventoryInManager();
            if (inven.ItemList["씨앗_호박"] > 0)
            {
                equip = GrowPlant.Equip.Pumpkin;
                plant.SetTile(equip);
                inven.ItemList["씨앗_호박"]--;
                button[2].GetComponentInChildren<Text>().text = "X " + inven.ItemList["씨앗_호박"].ToString();
                gameObject.SetActive(false);
            }
            else Debug.Log("부족함");
        });
    }
    public void Refresh()
    {
        Inventory s_inven = manager.GetInventoryInManager();
        button[0].GetComponentInChildren<Text>().text = "X " + s_inven.ItemList["씨앗_딸기"].ToString();
        button[1].GetComponentInChildren<Text>().text = "X " + s_inven.ItemList["씨앗_수박"].ToString();
        button[2].GetComponentInChildren<Text>().text = "X " + s_inven.ItemList["씨앗_호박"].ToString();
    }
    private void OnEnable()
    {
        Refresh();
    }
}
