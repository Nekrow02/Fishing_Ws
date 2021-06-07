using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public Dictionary<string, int> ItemList ;
    
    public Item()
    {
        ItemList = new Dictionary<string, int>();
        ItemList.Add("농사기구",100);
        ItemList.Add("씨앗1",10);
        ItemList.Add("씨앗2",20);
        ItemList.Add("씨앗3", 30);
        ItemList.Add("씨앗4", 40);
        ItemList.Add("낚싯대1", 50);
        ItemList.Add("낚싯대2", 150);
        ItemList.Add("떡밥", 0);
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
            ItemList.Add("농사기구", 0);
            ItemList.Add("씨앗1", 0);
            ItemList.Add("씨앗2", 0);
            ItemList.Add("씨앗3", 0);
            ItemList.Add("씨앗4", 0);
            ItemList.Add("낚싯대1", 0);
            ItemList.Add("낚싯대2", 0);
            ItemList.Add("떡밥", 0);
        }
    }
}
