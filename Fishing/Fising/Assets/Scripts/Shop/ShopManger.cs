using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManger : MonoBehaviour
{
    [SerializeField]
    private S_GameManager s_manager;
    private Item item = new Item();
    private int money = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Sell(int idx)
    {
        switch (idx)
        {
            case 0:
                {
                    if (s_manager.Fish_stack_E_Song > 0)
                    {
                        s_manager.Fish_stack_E_Song--;
                        money += 100;
                    }
                    else
                    {
                        Debug.Log("없는건 못팔아");
                    }
                    break;
                };
            case 1:
                {
                    if (s_manager.Fish_stack_E_Boong > 0)
                    {
                        s_manager.Fish_stack_E_Boong--;
                        money += 120;
                    }
                    else
                    {
                        Debug.Log("없는건 못팔아");
                    }
                    break;
                };
            case 2:
                {
                    if (s_manager.Fish_stack_E_Mi > 0)
                    {
                        s_manager.Fish_stack_E_Mi--;
                        money += 150;
                    }
                    else
                    {
                        Debug.Log("없는건 못팔아");
                    }
                    break;
                };

            case 3:
                {
                    if (s_manager.Fish_stack_N_Do > 0)
                    {
                        s_manager.Fish_stack_N_Do--;
                        money += 230;
                    }
                    else
                    {
                        Debug.Log("없는건 못팔아");
                    }
                    break;
                };
            case 4:
                {
                    if (s_manager.Fish_stack_N_Nong > 0)
                    {
                        s_manager.Fish_stack_N_Nong--;
                        money += 250;
                    }
                    else
                    {
                        Debug.Log("없는건 못팔아");
                    }
                    break;
                };
            case 5:
                {
                    if (s_manager.Fish_stack_N_Gang > 0)
                    {
                        s_manager.Fish_stack_N_Gang--;
                        money += 250;
                    }
                    else
                    {
                        Debug.Log("없는건 못팔아");
                    }
                    break;
                };
            case 6:
                {
                    if (s_manager.Fish_stack_L_Sang > 0)
                    {
                        s_manager.Fish_stack_L_Sang--;
                        money += 1000;
                    }
                    else
                    {
                        Debug.Log("없는건 못팔아");
                    }
                    break;
                };
            case 7:
                {
                    if (s_manager.Fish_stack_L_Cham > 0)
                    {
                        s_manager.Fish_stack_L_Cham--;
                        money += 800;
                    }
                    else
                    {
                        Debug.Log("없는건 못팔아");
                    }
                    break;
                };
            case 8:
                {
                    if (s_manager.Fish_stack_L_Ga > 0)
                    {
                        s_manager.Fish_stack_L_Ga--;
                        money += 900;
                    }
                    else
                    {
                        Debug.Log("없는건 못팔아");
                    }
                    break;
                };
        }
    }
    public void Buy(string item)
    {
        if (money - this.item.ItemList[item] > 0)
        {
            Inventory inven = s_manager.GetInventoryInManager();
            money -= this.item.ItemList[item];
            inven.ItemList[item]++;
        }
        else
        {
            Debug.Log("돈없으면 집에가서 빈대떡이나 부쳐먹지");
        }
    }
    public void SellString(string item)
    {
        Inventory inven = s_manager.GetInventoryInManager();
        if ( inven.ItemList[item] > 0)
        {
            money += this.item.ItemList[item];
            inven.ItemList[item]--;
        }
        else
        {
            Debug.Log("없는건 못팔아");
        }
    }
}
