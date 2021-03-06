using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    [SerializeField] private string[] corAns;
    public GameController game;
    public HUDHandler roundOver;
    public void CorrectAns(string input)
    {
        string corrAns = input;
        for(int i=0; i<corAns.Length;i++)
        {
            if(string.Equals(corrAns,corAns[i]))
            {
                Debug.Log(corAns[i]);
                game.nextButton.interactable = true;
            }
            if(string.Equals(corrAns,corAns[corAns.Length-1]))
            {
                roundOver.ActiveGameState(HUDstate.GameOver);
                roundOver.Clean();
            }
        }
            
    }
}
