using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scriptRespaw : MonoBehaviour
{
    public GameObject PC;
    public float largura;
    private bool pausado = false;
    void Start()
    {
        largura = Camera.main.orthographicSize * Camera.main.aspect;
        InvokeRepeating("respawn", 0, 1);
    }

    private void respawn()
    {
        float posX = Random.Range(-largura, largura);
        Vector2 posicao = new Vector2(posX, Camera.main.orthographicSize + 1);
        Instantiate(PC, posicao, Quaternion.identity);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                pausado = false;
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(0);
            }
            else
            {
                pausado = true;
                Time.timeScale = 0;
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
            }
        }
    }
}
