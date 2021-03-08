using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject[] scenesArray = new GameObject[0];
    private int scenesIndex = 0;
    public GameObject prefabPos;//prefabs will instantiate under this panel
    //private Vector3 sceneDisplayPosition = new Vector3(0.34f, 0.074f, 0);

    void Start()
    {
        Object[] ScenePrefabs = Resources.LoadAll("ScenesPrefab",typeof(GameObject));
        scenesArray = new GameObject[ScenePrefabs.Length];
        for (int i = 0; i < ScenePrefabs.Length; i++)
        {
            scenesArray[i] = (GameObject)Instantiate(ScenePrefabs[i],prefabPos.transform);
            //scenesArray[i].transform.localScale = new Vector3(10, 10, 10);
            scenesArray[i].SetActive(false);
            //SetActive(false) makes this object inactive - it dissapears, cannot be interacted with in any way, but it is still in the scene
        }

        plusPrefabs(0);
    }

    // Update is called once per fram

    public void OnClickRightArrow()
    {
        plusPrefabs(1);
    }

    public void OnClickLeftArrow()
    {
        plusPrefabs(-1);
    }

    public void plusPrefabs(int n)
    {
        scenesIndex += n;
        if (scenesIndex < 0) scenesIndex = scenesArray.Length - 1;
        if (scenesIndex >= scenesArray.Length) scenesIndex = 0;

        for (int i = 0; i < scenesArray.Length; i++)
        {
            scenesArray[i].SetActive(false);
        }
        scenesArray[scenesIndex].SetActive(true);
    }
}
