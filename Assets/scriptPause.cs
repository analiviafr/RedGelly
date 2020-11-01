using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPause : MonoBehaviour
{
    private bool isPause;
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;

            if (isPause)
            {
                Pause();
                SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
            }

            else
            {
                UnPause();
                SceneManager.UnloadSceneAsync(2);
            }
        }
    }
}