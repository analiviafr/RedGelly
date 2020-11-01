using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPC : MonoBehaviour
{
    private Rigidbody2D rbd;
    private Animator anim;
    public float velocidade = 7;
    public float pulo = 550;
    private bool chao = false;
    private bool direita = true;
    public LayerMask mascara;
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        chao = true;

        if (collision.gameObject.tag.Equals("Armadilha"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(3);
        }

        else if (collision.gameObject.tag.Equals("Inimigo"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(3);
        }

        else if (collision.gameObject.tag.Equals("Bau"))
        {
            SceneManager.LoadScene(4);
        }

        transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        chao = false;
        transform.parent = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Inimigo"))
        {
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag.Equals("Armadilha"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(3);
        }

    }
    void Update()
    {
        Debug.Log(chao);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float vely;

        if (chao)
        {
            vely = 0;
            anim.SetBool("pulando", false);
        }
        else
        {
            vely = rbd.velocity.y;
            anim.SetBool("pulando", true);
        }

        if (x == 0)
        {
            anim.SetBool("parado", true);
        }

        else
        {
            anim.SetBool("parado", false);
        }

        if (direita && x < 0 || !direita && x > 0)
        {
            direita = !direita;
            transform.Rotate(new Vector2(0, 180));
        }

        rbd.velocity = new Vector2(x * velocidade, vely);

        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            chao = false;
            rbd.AddForce(new Vector2(0, pulo));

        }

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, -transform.up, 0.5f, mascara);
        if (hit.collider != null)
            Destroy(hit.collider.gameObject);
    }
}
