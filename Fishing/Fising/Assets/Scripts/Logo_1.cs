using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo_1 : MonoBehaviour
{

    public GameObject Logo_Fishing, Btn_exit, Btn_start, Btn_Logo;
    Transform tr_L;
    float movespeed;


    Button Btn;
    ColorBlock cb;
    Color newColor;

    int i_C;

    bool b_btn_logo;

    // Start is called before the first frame update
    void Start()
    {
        b_btn_logo = false;

        tr_L = Logo_Fishing.GetComponent<Transform>();
        movespeed = 1f;

        Btn = Btn_Logo.GetComponent<Button>();

        cb = Btn.colors;

        i_C = 0;


        InvokeRepeating("Change_color", 0f, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {

        if(tr_L.position.y < -1.85f)
        {
            Vector2 target_L = new Vector2(tr_L.position.x, tr_L.position.y + 1f);
            tr_L.position = Vector2.MoveTowards(tr_L.position, target_L, movespeed * Time.deltaTime);
        }
        else if(!b_btn_logo)
        {
            Btn_Logo.SetActive(true);
            b_btn_logo = true;
        }


        cb.normalColor = newColor;

        Btn.colors = cb;

    }


    void Change_color()
    {
        i_C++;

        switch (i_C)
        {
            case 0:
                newColor = Color.red;
                break;
            case 1:
                newColor = Color.yellow;

                break;
            case 2:
                newColor = Color.green;

                break;
            case 3:
                newColor = Color.cyan;

                break;
            case 4:
                newColor = Color.blue;

                break;
            case 5:
                newColor = Color.grey;

                break;
            case 6:
                newColor = Color.magenta;
                i_C = 0;

                break;

        }

    }

    public void Logo_Click()
    {
        Btn_exit.SetActive(true);
        Btn_start.SetActive(true);

        Btn_Logo.SetActive(false);
    }


}
