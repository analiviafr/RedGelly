using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptInimigo : MonoBehaviour
{
    public float velocidade = 5;
    public float distancia = 0.4f;
    private Rigidbody2D rbd;
    public LayerMask mascara;
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

        void Update()
    {
        rbd.velocity = new Vector2(velocidade, 0);

        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, transform.right, distancia, mascara);

        if (hit.collider != null)
        {
            transform.Rotate(new Vector2(0, 180));
            velocidade = -velocidade;
            rbd.velocity = new Vector2(velocidade, 0);
        }

    }
}
