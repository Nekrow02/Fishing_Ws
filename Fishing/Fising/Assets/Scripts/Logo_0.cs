using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo_0 : MonoBehaviour
{

    public GameObject Logo_Char;
    Transform tr, tr_L;
    float movespeed;


    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        movespeed = 1f;


    }

    // Update is called once per frame
    void Update()
    {
        if(tr.position.x < 0)
        {
            Vector2 target = new Vector2(tr.position.x + 1f, tr.position.y);
            transform.position = Vector2.MoveTowards(tr.position, target, movespeed * Time.deltaTime);

        }
        else 
        {

            this.gameObject.SetActive(false);
            Logo_Char.SetActive(true);

        }





    }
}
