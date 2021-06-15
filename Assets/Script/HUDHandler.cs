using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDHandler : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject MainGame;
    [SerializeField] private GameObject GameOverPanel;
    //[SerializeField] private GameObject SettingPanel;


    //[SerializeField] private Text playerText;

    //private bool twoPlayer;

    private void Start()
    {
        ActiveGameState(HUDstate.Menu);
    }

    public void ActiveGameState(HUDstate state)
    {
        if (state == HUDstate.Menu)
        {
            MainMenuPanel.SetActive(true);
            MainGame.SetActive(false);
            GameOverPanel.SetActive(false);
            //SettingPanel.SetActive(false);

        }
        //else if (state == HUDstate.selection)
        //{
        //    SettingPanel.SetActive(true);
        //    MenuPanel.SetActive(false);
        //    MainPanel.SetActive(false);
        //}
        else if (state == HUDstate.Game)
        {
            MainGame.SetActive(true);
            MainMenuPanel.SetActive(false);
            //SettingPanel.SetActive(false);
        }
        else
            GameOverPanel.SetActive(true);
    }




    public void OnClickPlay()
    {
        ActiveGameState(HUDstate.Game);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickReturn()
    {
        ActiveGameState(HUDstate.Menu);
        Clean();
    }
    //public void OnClickPlayer()
    //{
     //   ActiveGameState(HUDstate.Game);
    //}

    public void Clean()
    {
        PlayerPrefs.DeleteAll();
    }

    
}
