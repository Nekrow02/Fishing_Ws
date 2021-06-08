using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Info : MonoBehaviour
{

    public string f_name;
    public float f_size;
    public int f_fish;
    public GameObject GMR;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log(f_name + f_size + f_fish);

            Destroy(gameObject);
        }
    }


    public void Fish_Input(string n, float s, int f)
    {
        f_name = n;
        f_size = s;
        f_fish = f;

    }


}
