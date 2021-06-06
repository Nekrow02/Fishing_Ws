using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Fish_Move : MonoBehaviour
{

    public float movespeed;
    bool Left_move = true;
    string now_Pos;
    Transform tr;
    float ran_speed_delay, ran_speed;
    float ran_bool_delay, ran_bool;
    public Image Hp_bar, Skill_bar;

    float Fish_HP_now, Fish_HP_cur;
    float skill_cool_now, skill_cool_cur;

    public GameObject GMR;
    public GameObject songsari, boongo, migguragi;
    public GameObject domi, nongo, gango;
    public GameObject l_sango, l_chamchi, l_gabokchi;
    GameObject Player;
    GameObject Fish_R;

    Vector3 player_point;
    Vector3 fish_point;

    bool b_wAttack = false;
    bool b_wAttack_cool = true;

    int dif;
    int f_num;

    float R_Speed_delay_Min, R_Speed_delay_Max, R_Bool_delay_Min, R_Bool_delay_Max;
    float R_Speed_Min, R_Speed_Max;

    public bool succes = false;

    string f_name;
    float f_size;

    public GameObject Hit_Effect;
    GameObject effect;




    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Random_float", 0f);
        Difficulty();

        tr = GetComponent<Transform>();
        Fish_HP_now = 50f;
        Fish_HP_cur = 100f;

        skill_cool_now = 1000f;
        skill_cool_cur = 1000f;

        GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Char_Move>().moving = false;

        GMR.GetComponent<S_GameManager>().PressF = false;

        Player = GameObject.FindGameObjectWithTag("PLAYER");
        fish_point.y = 0.16f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Left_move)
        {
            Vector2 target = new Vector2(tr.position.x - 1f, tr.position.y);
            transform.position = Vector2.MoveTowards(tr.position, target, movespeed * Time.deltaTime);
        }
        else if (!Left_move)
        {
            Vector2 target = new Vector2(tr.position.x + 1f, tr.position.y);
            transform.position = Vector2.MoveTowards(tr.position, target, movespeed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            Vector2 target = new Vector2(tr.position.x + 1f, tr.position.y);
            //transform.position = Vector2.MoveTowards(tr.position, target, 0.005f);
            transform.position = Vector2.MoveTowards(tr.position, target, 0.2f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector2 target = new Vector2(tr.position.x - 1f, tr.position.y);
            //transform.position = Vector2.MoveTowards(tr.position, target, 0.005f);
            transform.position = Vector2.MoveTowards(tr.position, target, 0.2f);
        }

        if (Input.GetKeyDown(KeyCode.W) && b_wAttack_cool)
        {
            if(b_wAttack)
            {
                Fish_HP_now += 10f;
                effect = Instantiate(Hit_Effect, this.transform.position, Quaternion.identity);
                
            }
            b_wAttack_cool = false;
            skill_cool_now = 0;

        }


        if (Fish_HP_now <= 0)
        {
            GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Char_Move>().moving = true;
            GameObject.FindGameObjectWithTag("GAMEMGR").GetComponent<S_GameManager>().PressF = true;
            print(tr.parent.gameObject.name);




            GMR.GetComponent<S_GameManager>().PressF = true;

            //GMR.GetComponent<S_GameManager>().Fishing_fail();

            Destroy_Self();



        }
        else if(Fish_HP_now >= 100)
        {
            GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Char_Move>().moving = true;
            GameObject.FindGameObjectWithTag("GAMEMGR").GetComponent<S_GameManager>().PressF = true;
            //print(tr.parent.gameObject.name);

            GMR.GetComponent<S_GameManager>().PressF = true;

            //GMR.GetComponent<S_GameManager>().Fishing_su();

            succes = true;

            Fish_Result();


            Destroy_Self();

        }

        if (this.transform.localPosition.x >= 0.4f || this.transform.localPosition.x <= -0.4f)
        {
            Fish_HP_now -= 0.03f;
            b_wAttack = false;
            Debug.Log(this.transform.localPosition);
        }

        if(this.transform.localPosition.x < 0.4f && this.transform.localPosition.x > -0.4f)
        {
            Fish_HP_now += 0.05f;
            b_wAttack = true;
            Debug.Log("hu++i");
        }


        if(b_wAttack_cool == false)
        {
            skill_cool_now++;
            if (skill_cool_now >= 1000)
            {
                WAttack_Cool();

            }
            //Debug.Log(skill_cool_now);
        }


        Skill_bar.fillAmount = skill_cool_now / skill_cool_cur;
        Hp_bar.fillAmount = Fish_HP_now / Fish_HP_cur;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        now_Pos = collision.name;


        switch(collision.name)
        {
            case "Left_Wall_0":
                Left_move = false;
                break;
            case "Right_Wall_0":
                Left_move = true;
                break;
        }

    }

    void Random_float()
    {
        switch(dif)
        {
            case 0:
                R_Speed_delay_Min = 4.0f;
                R_Speed_delay_Max = 7.0f;
                R_Bool_delay_Min = 4.0f;
                R_Bool_delay_Max = 7.0f;
                Debug.Log("Easy");

                break;

            case 1:
                R_Speed_delay_Min = 1.0f;
                R_Speed_delay_Max = 7.0f;
                R_Bool_delay_Min = 1.0f;
                R_Bool_delay_Max = 7.0f;
                Debug.Log("Nomal");

                break;

            case 2:
                R_Speed_delay_Min = 0.0f;
                R_Speed_delay_Max = 4.0f;
                R_Bool_delay_Min = 0.0f;
                R_Bool_delay_Max = 4.0f;
                Debug.Log("Hard");

                break;
        }
        //R_Speed_delay_Min, R_Speed_delay_Max, R_Bool_delay_Min, R_Bool_delay_Max
        ran_speed_delay = UnityEngine.Random.Range(R_Speed_delay_Min, R_Speed_delay_Max);
        ran_bool_delay = UnityEngine.Random.Range(R_Bool_delay_Min, R_Bool_delay_Max);
        InvokeRepeating("Random_Speed", 0f, ran_speed_delay);
        InvokeRepeating("Random_Bool", 0f, ran_bool_delay);
    }
    void Random_Speed()
    {
        switch (dif)
        {
            case 0:
                R_Speed_Min = 0.0f;
                R_Speed_Max = 1.0f;
                break;

            case 1:
                R_Speed_Min = 0.5f;
                R_Speed_Max = 2.0f;
                break;

            case 2:
                R_Speed_Min = 1.5f;
                R_Speed_Max = 3.0f;
                break;
        }


        ran_speed = UnityEngine.Random.Range(R_Speed_Min, R_Speed_Max);
        movespeed = ran_speed;
        ran_speed_delay = UnityEngine.Random.Range(R_Speed_delay_Min, R_Speed_delay_Max);
    }
    void Random_Bool()
    {
        ran_bool = UnityEngine.Random.Range(0, 2);
        if(ran_bool == 0)
        {
            Left_move = true;
        }
        else if (ran_bool == 1)
        {
            Left_move = false;
        }
        ran_bool_delay = UnityEngine.Random.Range(0.0f, 5.0f);
    }

    void WAttack_Cool()
    {
        b_wAttack_cool = true;

    }


    void Difficulty()
    {
        dif = UnityEngine.Random.Range(0, 3);           // 0 1 2


        Random_float();

    }

    void Destroy_Self()
    {
        Destroy(tr.parent.gameObject);

    }

    void Fish_Result()
    {
        player_point = Player.transform.position;

        switch(dif)
        {
            case 0:
                Random_Fish_Easy();

                break;

            case 1:
                Random_Fish_Nomal();

                break;

            case 2:
                Random_Fish_Legend();

                break;
        }


        //GMR.GetComponent<S_GameManager>().Fishing_succes(name, size, fish);

        Fish_R.GetComponent<Fish_Info>().Fish_Input(f_name, f_size, f_num);

    }



    void Random_Fish_Easy()
    {
        int random = UnityEngine.Random.Range(0, 3);

        switch(random)
        {
            case 0:
                Fish_R = Instantiate(songsari, (player_point + fish_point), Player.transform.rotation);

                f_name = "songsari";
                f_size = 1.2f;
                f_num = 0;


                break;

            case 1:
                Fish_R = Instantiate(boongo, (player_point + fish_point), Player.transform.rotation);

                f_name = "boongo";
                f_size = 2.4f;
                f_num = 1;

                break;

            case 2:
                Fish_R = Instantiate(migguragi, (player_point + fish_point), Player.transform.rotation);

                f_name = "migguragi";
                f_size = 0.2f;
                f_num = 2;

                break;

        }



    }

    void Random_Fish_Nomal()
    {
        int random = UnityEngine.Random.Range(0, 3);

        switch (random)
        {
            case 0:
                Fish_R = Instantiate(domi, (player_point + fish_point), Player.transform.rotation);

                f_name = "domi";
                f_size = 1.2f;
                f_num = 3;


                break;

            case 1:
                Fish_R = Instantiate(nongo, (player_point + fish_point), Player.transform.rotation);

                f_name = "nongo";
                f_size = 2.4f;
                f_num = 4;


                break;

            case 2:
                Fish_R = Instantiate(gango, (player_point + fish_point), Player.transform.rotation);

                f_name = "gango";
                f_size = 0.2f;
                f_num = 5;


                break;

        }



    }

    void Random_Fish_Legend()
    {
        int random = UnityEngine.Random.Range(0, 3);

        switch (random)
        {
            case 0:
                Fish_R = Instantiate(l_sango, (player_point + fish_point), Player.transform.rotation);

                f_name = "l_sango";
                f_size = 1.2f;
                f_num = 6;

                break;

            case 1:
                Fish_R = Instantiate(l_chamchi, (player_point + fish_point), Player.transform.rotation);

                f_name = "l_chamchi";
                f_size = 2.4f;
                f_num = 7;

                break;

            case 2:
                Fish_R = Instantiate(l_gabokchi, (player_point + fish_point), Player.transform.rotation);

                f_name = "l_gabokchi";
                f_size = 0.2f;
                f_num = 8;

                break;

        }



    }





}
