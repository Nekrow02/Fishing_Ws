using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public Dictionary<string, int> ItemList ;
    
    public Item()
    {
        ItemList = new Dictionary<string, int>();
        //ItemList.Add("농사기구",100);
        ItemList.Add("씨앗_딸기", 90);
        ItemList.Add("씨앗_수박", 200);
        ItemList.Add("씨앗_호박", 250);
        ItemList.Add("열매_딸기", 150);
        ItemList.Add("열매_수박", 400);
        ItemList.Add("열매_호박", 650);
        //ItemList.Add("씨앗4", 40);
        ItemList.Add("낚싯대1", 5000);
        ItemList.Add("낚싯대2", 15000);
        ItemList.Add("낚싯대3", 40000);
        //ItemList.Add("떡밥", 0);
    }
}

public class Inventory
{
    public Dictionary<string, int> ItemList;

    public Inventory(Global.PlayType type)
    {
        if(type == Global.PlayType.START)
        {
            ItemList = new Dictionary<string, int>();
            //ItemList.Add("농사기구", 0);
            ItemList.Add("씨앗_딸기", 0);
            ItemList.Add("씨앗_수박", 0);
            ItemList.Add("씨앗_호박", 0);
            ItemList.Add("열매_딸기", 0);
            ItemList.Add("열매_수박", 0);
            ItemList.Add("열매_호박", 0);
            ItemList.Add("낚싯대1", 0);
            ItemList.Add("낚싯대2", 0);
            ItemList.Add("낚싯대3", 0);
            //ItemList.Add("떡밥", 0);
        }
    }
}
