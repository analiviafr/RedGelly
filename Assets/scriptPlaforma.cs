using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlaforma : MonoBehaviour
{
    private float cont = 0;
    public float velocidade = 3;
    private Vector2 posInicial;
    public float altura = 1;
    public float largura = 1;

    void Start()
    {
        posInicial = transform.position;
    }

    void Update()
    {
        cont += velocidade * Time.deltaTime;

        float posX = Mathf.Cos(cont)*largura;
        float posY = Mathf.Sin(cont)*altura;

        Vector2 posAtual = new Vector2(posX, posY);

        transform.position = posInicial + posAtual;

        if (cont >= 2*Mathf.PI)
        {

            cont = 2 * Mathf.PI - cont;
        }
    }
}
