using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Hit_Destroy", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Hit_Destroy()
    {
        Destroy(gameObject);
    }
}
