using TMPro;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float HorizontalMovement;
    public float VerticalMovement;
    public float Speed;

    public bool HasRune;
    public int Bullets = 0; // NUEVO

    public GameObject BulletPrefab;

    public Sprite Front;
    public Sprite Back;
    public Sprite Left;
    public Sprite Right;

    public Animator animator;

    public GameObject menuMuerto;

    public GameObject menuVictoria;

    public int fuentesActivadas;

    const int fuentesNecesarias = 8;

    public TMP_Text textoFuentes;

    public int vidas = 3;

    public Animator vidasAnimator;

    void Update()
    {
        MovementPlayer();

        if (HasRune)
        {
            Shoot();
        }

        if (fuentesActivadas >= fuentesNecesarias)
        {
            Victoria();
        }

        textoFuentes.text = "Fuentes: " + fuentesActivadas + "/" + fuentesNecesarias;
    }

    private void Victoria()
    {
        //muestra el menu de muerto
        menuVictoria.SetActive(true);

        //destruye al jugador
        Destroy(gameObject);
    }

    public void QuitarVida()
    {
        vidas -= 1;

        vidasAnimator.SetInteger("vidas", vidas);

        if (vidas <= 0)
        {
            //muestra el menu de muerto
            menuMuerto.SetActive(true);

            //destruye al jugador
            Destroy(gameObject);
        }
    }

    public void MovementPlayer()
    {
        //Debug.Log("Player try to move");

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Version antigua para animar
        /*
        if (x > 0)
        {
            SR.sprite = Right;
        }
        else if (x < 0)
        {
            SR.sprite = Left;
        }
        else if (y > 0)
        {
            SR.sprite = Back;
        }
        else if (y < 0)
        {
            SR.sprite = Front;
        }
        */

        Vector3 dir = new Vector3(x, y, 0);
        dir.Normalize();

        if (dir != Vector3.zero)
        {
            animator.SetFloat("X", dir.x);
            animator.SetFloat("Y", dir.y);

            animator.SetBool("correr", true);

            transform.position += dir * Speed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("correr", false);
        }
    }

    public void Shoot()
    {
        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction =
            mousePos - transform.position;

        direction.z = 0;
        direction.Normalize();

        if (Input.GetMouseButtonDown(0) && Bullets > 0)
        {
            Debug.Log("DISPARÉ");

            GameObject bullet =
                Instantiate(
                    BulletPrefab,
                    transform.position,
                    Quaternion.identity);

            bullet.transform.up = direction;

            Bullets--;

            if (Bullets <= 0)
            {
                HasRune = false;
            }
        }
    }
}