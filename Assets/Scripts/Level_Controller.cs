using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Controller : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            ReloadLevel();
        }
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene("Level01");

    }
}
