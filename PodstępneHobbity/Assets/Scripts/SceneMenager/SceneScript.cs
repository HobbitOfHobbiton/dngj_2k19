using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    [SerializeField]
    bool LastLevel = false;

    void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
        Test();
    }

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.V))
            NextLevel();
        if (Input.GetKeyDown(KeyCode.R))
            ResetLevel();
    }

    public void NextLevel ()
    {
        if(LastLevel == false)
        {
            string LevelName = SceneManager.GetActiveScene().name;
            int LevelNumber = ((int)LevelName[LevelName.Length - 2] -48 )* 10 + (int)LevelName[LevelName.Length - 1] - 48;
            LevelNumber++;
            if (LevelNumber <10)
                SceneManager.LoadScene("scene_0" + LevelNumber);
            else
                SceneManager.LoadScene("scene_" + LevelNumber);
        }
        else
        {
            SceneManager.LoadScene("End");
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
