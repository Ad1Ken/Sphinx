using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    void update()
    {
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        yield return new WaitForSeconds(2f);
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextRiddle(int p)
    {
        index += p;
        if(index < 0)
        {
            index = sentences.Length - 1;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else if(index >= sentences.Length)
        {
            index = 0;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            StartCoroutine(Type());
        }
    }
}
