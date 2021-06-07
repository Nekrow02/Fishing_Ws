using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_GameManager : MonoBehaviour
{

    public GameObject Fishing_Tab, Ex_1, cam, player;

    Vector3 Cam_z;

    public bool PressF = false;
    bool spawntime = false;
    bool miss = false;
    public bool fishing = false;

    bool playing = false;

    float delay;

    Vector3 player_point;
    Vector3 alam_point;

    GameObject ex;

    public GameObject Player_Sprite;
    private Animator Player_Ani;

    public GameObject Fishs_R;

    public GameObject Fish_tab;

    public int Fish_stack_E_Song = 0;
    public int Fish_stack_E_Boong = 0;
    public int Fish_stack_E_Mi = 0;
    public int Fish_stack_N_Do = 0;
    public int Fish_stack_N_Nong = 0;
    public int Fish_stack_N_Gang = 0;
    public int Fish_stack_L_Sang = 0;
    public int Fish_stack_L_Cham = 0;
    public int Fish_stack_L_Ga = 0;

    int f_fish;
    bool f_stack;

    public Text stack_E;
    public Text stack_N;
    public Text stack_L;

    public GameObject Game_Canvas, Once, press_esc;

    ///주찬

    [SerializeField]
    private Global.PlayType startType;
    private Inventory inven;
    // Start is called before the first frame update
    void Start()
    {
        PressF = false;
        Cam_z = new Vector3(0, 0, 10);

        alam_point.x = 0.08f;
        alam_point.y = 0.1f;

        Player_Ani = Player_Sprite.GetComponent<Animator>();


        f_fish = -1;
        f_stack = true;

        Load_Data();
        Debug.Log("load");



        Update_Stack();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && PressF == true && spawntime == false)
        {
            if (miss == false)
            {
                delay = Random.Range(2f, 10f);

                Invoke("timing", delay);
            }
            else if (miss == true)
            {
                miss = false;
                Invoke("timing", delay + 0.01f);
            }

            playing = false;

            PressF = false;
            fishing = true;
            Player_Ani.SetBool("b_Fishing", true);
        }

        if (Input.GetKeyDown(KeyCode.W) && spawntime == true)
        {
            Invoke("FisingTab_Spwan", 0.2f);
        }

        if (Input.GetKeyDown(KeyCode.W) && spawntime == false && PressF == false && playing == false)
        {
            Player_Ani.SetBool("b_Fishing", false);
            PressF = true;
            miss = true;
            timing_destroy();
        }



        if(GameObject.FindGameObjectWithTag("FISHS") && f_stack)
        {
            f_fish = GameObject.FindGameObjectWithTag("FISHS").GetComponent<Fish_Info>().f_fish;
            
            switch(f_fish)
            {
                case 0:
                    Fish_stack_E_Song++;

                    break;

                case 1:
                    Fish_stack_E_Boong++;

                    break;

                case 2:
                    Fish_stack_E_Mi++;

                    break;

                case 3:
                    Fish_stack_N_Do++;

                    break;

                case 4:
                    Fish_stack_N_Nong++;

                    break;

                case 5:
                    Fish_stack_N_Gang++;

                    break;

                case 6:
                    Fish_stack_L_Sang++;

                    break;

                case 7:
                    Fish_stack_L_Cham++;

                    break;

                case 8:
                    Fish_stack_L_Ga++;

                    break;
            }

            Update_Stack();

            f_stack = false;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            f_stack = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && Game_Canvas.activeSelf == false)
        {
            Destroy(press_esc);
            Game_Canvas.SetActive(true);
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Game_Canvas.activeSelf)
        {
            Game_Canvas.SetActive(false);
            Time.timeScale = 1;
        }


    }



    void timing()
    {
        if (spawntime == false && miss == false)
        {
            ex = Instantiate(Ex_1, (player.transform.position + alam_point)
                  + Cam_z, player.transform.rotation);
            spawntime = true;
            Invoke("timing_destroy", 2f);
        }

    }



    void timing_destroy()
    {
        spawntime = false;
        PressF = true;
        fishing = false;
        Player_Ani.SetBool("b_Fishing", false);

        Destroy(ex);
    }


    void FisingTab_Spwan()
    {
        Fish_tab = Instantiate(Fishing_Tab, cam.transform.position + Cam_z, cam.transform.rotation);
        spawntime = false;
        playing = true;
        Player_Ani.SetBool("b_Fishing", false);

        Destroy(ex);
        
    }


    public void Update_Stack()
    {
        stack_E.text =  "[송사리] " + Fish_stack_E_Song + " 마리\n\n" +
                        "[붕어] " + Fish_stack_E_Boong + " 마리\n\n" + 
                        "[미꾸라지] " + Fish_stack_E_Mi + " 마리\n";

        stack_N.text = "[도미] " + Fish_stack_N_Do + " 마리\n\n" +
                "[농어] " + Fish_stack_N_Nong + " 마리\n\n" +
                "[광어] " + Fish_stack_N_Gang + " 마리\n";

        stack_L.text = "[상어] " + Fish_stack_L_Sang + " 마리\n\n" +
                "[참치] " + Fish_stack_L_Cham + " 마리\n\n" +
                "[개복치] " + Fish_stack_L_Ga + " 마리\n";
    }



    void Load_Data()
    {
        ///주찬
        inven = new Inventory(startType);
        GetStartInventory();
        ///
        if (PlayerPrefs.HasKey("s_Fish_stack_E_Song"))
        {
            Fish_stack_E_Song = PlayerPrefs.GetInt("s_Fish_stack_E_Song");
            Fish_stack_E_Boong = PlayerPrefs.GetInt("s_Fish_stack_E_Boong");
            Fish_stack_E_Mi = PlayerPrefs.GetInt("s_Fish_stack_E_Mi");

            Fish_stack_N_Do = PlayerPrefs.GetInt("s_Fish_stack_N_Do");
            Fish_stack_N_Nong = PlayerPrefs.GetInt("s_Fish_stack_N_Nong");
            Fish_stack_N_Gang = PlayerPrefs.GetInt("s_Fish_stack_N_Gang");

            Fish_stack_L_Sang = PlayerPrefs.GetInt("s_Fish_stack_L_Sang");
            Fish_stack_L_Cham = PlayerPrefs.GetInt("s_Fish_stack_L_Cham");
            Fish_stack_L_Ga = PlayerPrefs.GetInt("s_Fish_stack_L_Ga");

            
        }
        else if(!PlayerPrefs.HasKey("s_Fish_stack_E_Song"))
        {
            PlayerPrefs.SetInt("s_Fish_stack_E_Song", Fish_stack_E_Song);
            PlayerPrefs.SetInt("s_Fish_stack_E_Boong", Fish_stack_E_Boong);
            PlayerPrefs.SetInt("s_Fish_stack_E_Mi", Fish_stack_E_Mi);

            PlayerPrefs.SetInt("s_Fish_stack_N_Do", Fish_stack_N_Do);
            PlayerPrefs.SetInt("s_Fish_stack_N_Nong", Fish_stack_N_Nong);
            PlayerPrefs.SetInt("s_Fish_stack_N_Gang", Fish_stack_N_Gang);

            PlayerPrefs.SetInt("s_Fish_stack_L_Sang", Fish_stack_L_Sang);
            PlayerPrefs.SetInt("s_Fish_stack_L_Cham", Fish_stack_L_Cham);
            PlayerPrefs.SetInt("s_Fish_stack_L_Ga", Fish_stack_L_Ga);
        }
    }

    ///주찬
    private void GetStartInventory()
    {
        if(startType == Global.PlayType.CONTINUE)
        {
            try
            {
                inven.ItemList.Add("농사기구", PlayerPrefs.GetInt("농사기구"));
                inven.ItemList.Add("씨앗1", PlayerPrefs.GetInt("씨앗1"));
                inven.ItemList.Add("씨앗2", PlayerPrefs.GetInt("씨앗2"));
                inven.ItemList.Add("씨앗3", PlayerPrefs.GetInt("씨앗3"));
                inven.ItemList.Add("씨앗4", PlayerPrefs.GetInt("씨앗4"));
                inven.ItemList.Add("낚싯대1", PlayerPrefs.GetInt("낚싯대1"));
                inven.ItemList.Add("낚싯대2", PlayerPrefs.GetInt("낚싯대2"));
                inven.ItemList.Add("농사기구", PlayerPrefs.GetInt("농사기구"));
                inven.ItemList.Add("떡밥", PlayerPrefs.GetInt("떡밥"));
            }
            catch
            {
                Debug.Log("저장된것이 없다.");
                inven = new Inventory(Global.PlayType.START);
                return;
            }
        }
    }
    public void SetStartInventory()
    {
        PlayerPrefs.SetInt("농사기구",inven.ItemList["농사기구"]);
        PlayerPrefs.SetInt("씨앗1", inven.ItemList["씨앗1"]);
        PlayerPrefs.SetInt("씨앗2", inven.ItemList["씨앗2"]);
        PlayerPrefs.SetInt("씨앗3", inven.ItemList["씨앗3"]);
        PlayerPrefs.SetInt("씨앗4", inven.ItemList["씨앗4"]);
        PlayerPrefs.SetInt("낚싯대1", inven.ItemList["낚싯대1"]);
        PlayerPrefs.SetInt("낚싯대2", inven.ItemList["낚싯대2"]);
        PlayerPrefs.SetInt("떡밥", inven.ItemList["떡밥"]);
    }
    public Inventory GetInventoryInManager()
    {
        return inven;
    }
}
