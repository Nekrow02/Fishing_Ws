using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Move : MonoBehaviour
{

    private float h, v, speed;
    Transform tr;
    string arrow_now;
    public bool moving = true;
    Vector2 Pos_now;

    public GameObject Player_Sprite;
    private Animator Player_Ani;
    public GameObject GameMGR;

    public bool Fising_point;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        //speed = 0.4f;
        speed = 0.2f;

        Player_Ani = Player_Sprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameMGR.GetComponent<S_GameManager>().fishing)
            Moveing();

    }


    void Moveing()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow) && moving)
        {
            Player_Ani.SetBool("b_Left", true);

            arrow_now = "Left";
            Pos_now = new Vector2(tr.position.x, tr.position.y);
            moving = false;

            InvokeRepeating("arrow_move", 0.02f, 0.02f);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && moving)
        {
            Player_Ani.SetBool("b_Right", true);

            arrow_now = "Right";
            Pos_now = new Vector2(tr.position.x, tr.position.y);
            moving = false;

            InvokeRepeating("arrow_move", 0.02f, 0.02f);

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && moving)
        {
            Player_Ani.SetBool("b_Up", true);

            arrow_now = "Up";
            Pos_now = new Vector2(tr.position.x, tr.position.y);
            moving = false;

            InvokeRepeating("arrow_move", 0.02f, 0.02f);

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && moving)
        {
            Player_Ani.SetBool("b_Down", true);

            arrow_now = "Down";
            Pos_now = new Vector2(tr.position.x, tr.position.y);
            moving = false;

            InvokeRepeating("arrow_move", 0.02f, 0.02f);

        }



    }

    void arrow_move()
    {
        switch (arrow_now)
        {
            case ("Left"):
                tr.Translate(Vector2.left * speed * Time.deltaTime);
                if (tr.position.x <= Pos_now.x - 0.16f)
                    Invoke("Cancel_arrow_move", 0f);
                break;
            case ("Right"):
                tr.Translate(Vector2.left * -1 * speed * Time.deltaTime);
                if (tr.position.x >= Pos_now.x + 0.16f)
                    Invoke("Cancel_arrow_move", 0f);
                break;
            case ("Up"):
                tr.Translate(Vector2.up * speed * Time.deltaTime);
                if (tr.position.y >= Pos_now.y + 0.16f)
                    Invoke("Cancel_arrow_move", 0f);
                break;
            case ("Down"):
                tr.Translate(Vector2.up * -1 * speed * Time.deltaTime);
                if (tr.position.y <= Pos_now.y - 0.16f)
                    Invoke("Cancel_arrow_move", 0f);
                break;
        }
        
    }

    void Cancel_arrow_move()
    {
        CancelInvoke("arrow_move");
        

        switch (arrow_now)
        {
            case ("Left"):
                tr.position = new Vector2(Pos_now.x - 0.16f, tr.position.y);
                Player_Ani.SetBool("b_Left", false);
                break;
            case ("Right"):
                tr.position = new Vector2(Pos_now.x + 0.16f, tr.position.y);
                Player_Ani.SetBool("b_Right", false);
                break;
            case ("Up"):
                tr.position = new Vector2(tr.position.x, Pos_now.y + 0.16f);
                Player_Ani.SetBool("b_Up", false);
                break;
            case ("Down"):
                tr.position = new Vector2(tr.position.x, Pos_now.y - 0.16f);
                Player_Ani.SetBool("b_Down", false);
                break;
        }
        moving = true;
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "WATER")
        {
            GameMGR.GetComponent<S_GameManager>().PressF = true;
            Player_Ani.SetBool("b_F_Idle", true);
        }

        if (collision.tag == "GRASS")
        {
            GameMGR.GetComponent<S_GameManager>().PressF = false;
            Player_Ani.SetBool("b_F_Idle", false);
        }
    }

}

