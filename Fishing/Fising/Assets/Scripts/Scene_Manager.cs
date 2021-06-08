using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{

    AudioSource Btn_Audio;
    public GameObject GMR;

    


    // Start is called before the first frame update
    void Start()
    {
        Btn_Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scene_Change_InGame()
    {
        Btn_Audio = GetComponent<AudioSource>();

        Btn_Audio.Play();

        SceneManager.LoadScene("2_InGame_EX");
    }

    public void Exit_Game()
    {
        Btn_Audio = GetComponent<AudioSource>();

        Btn_Audio.Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Retun_to_game()
    {
        this.transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    //public void Back_Game()
    //{
    //    Btn_Audio = GetComponent<AudioSource>();

    //    Btn_Audio.Play();
    //    Time.timeScale = 1;

    //    gameObject.transform.parent.gameObject.SetActive(false);
    //}

    public void Main_Menu()
    {
        Btn_Audio = GetComponent<AudioSource>();

        Debug.Log("save");

        PlayerPrefs.SetInt("s_Fish_stack_E_Song", GMR.GetComponent<S_GameManager>().Fish_stack_E_Song);
        PlayerPrefs.SetInt("s_Fish_stack_E_Boong", GMR.GetComponent<S_GameManager>().Fish_stack_E_Boong);
        PlayerPrefs.SetInt("s_Fish_stack_E_Mi", GMR.GetComponent<S_GameManager>().Fish_stack_E_Mi);

        PlayerPrefs.SetInt("s_Fish_stack_N_Do", GMR.GetComponent<S_GameManager>().Fish_stack_N_Do);
        PlayerPrefs.SetInt("s_Fish_stack_N_Nong", GMR.GetComponent<S_GameManager>().Fish_stack_N_Nong);
        PlayerPrefs.SetInt("s_Fish_stack_N_Gang", GMR.GetComponent<S_GameManager>().Fish_stack_N_Gang);

        PlayerPrefs.SetInt("s_Fish_stack_L_Sang", GMR.GetComponent<S_GameManager>().Fish_stack_L_Sang);
        PlayerPrefs.SetInt("s_Fish_stack_L_Cham", GMR.GetComponent<S_GameManager>().Fish_stack_L_Cham);
        PlayerPrefs.SetInt("s_Fish_stack_L_Ga", GMR.GetComponent<S_GameManager>().Fish_stack_L_Ga);


        Btn_Audio.Play();

        SceneManager.LoadScene("1_Menu");
    }



}
