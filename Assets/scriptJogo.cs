using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptJogo : MonoBehaviour
{
    public void Iniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void Inicio()
    {
        SceneManager.LoadScene(0);
    }
    public void Sair()
    {
        Application.Quit();
    }

    public void NovoJogo()
    {
        SceneManager.LoadScene(1);
    }

    public void Voltar()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(2);
    }
}
