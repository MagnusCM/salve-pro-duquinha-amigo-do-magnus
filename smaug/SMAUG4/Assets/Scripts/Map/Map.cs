using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public GameObject map;
    public static bool OnTheMap;

    void Start()
    {
        map.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (OnTheMap)
            {
                ResumeGame();
            }
        }

        if(Input.GetKeyUp(KeyCode.M))
        {
            if (!OnTheMap)
            {
                GoToMap();
            }
        }
    }

    public void GoToMap()
    {
        map.SetActive(true);
        Time.timeScale = 0f;
        OnTheMap = true;
    }

    public void ResumeGame()
    {
        map.SetActive(false);
        Time.timeScale = 1f;
        OnTheMap = false;
    }

    public void GoToFirstIsland()
    {
        map.SetActive(false);
        Time.timeScale = 1f;
        OnTheMap = false;
        SceneManager.LoadScene("SampleScene");
    }
}
