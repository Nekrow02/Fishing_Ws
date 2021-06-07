using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    //public Button shop_cancle_btn, shop_next_btn, shop_before_btn;

    public GameObject shop_ui;
    public GameObject[] shop_page;
    private int now_page;

    void Start()
    {
        now_page = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void shop_cancle_press()
    {
        shop_ui.SetActive(false);
        GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Char_Move>().moving = true;
        //now_page = 0;
    }

    public void shop_next_press()
    {
        if(now_page < 5)
        {

            shop_page[now_page].SetActive(false);
            now_page++;
            shop_page[now_page].SetActive(true);

        }
    }
    public void shop_before_press()
    {
        if(now_page >0)
        {
            shop_page[now_page].SetActive(false);
            now_page--;
            shop_page[now_page].SetActive(true);
        }
    }

}
