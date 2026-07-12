using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform Player;
    public float Speed;

    private bool IsFrozen = false;

    public Animator Animator;

    public float timeFrezze;

    const float empujeAlHacerHit = 50.0f;

    void Start()
    {

    }

    void Update()
    {
        FollowPlayer();
        UnfreezeEnemy();
    }

    public void FollowPlayer()
    {
        if (IsFrozen)
        {
            return;
        }

        if (Player != null)
        {
            Vector3 dir = Player.position - transform.position;

            dir.Normalize();

            if (dir != Vector3.zero)
            {
                Animator.SetFloat("X", dir.x);
                Animator.SetFloat("Y", dir.y);
            }

            transform.position += dir * Speed * Time.deltaTime;
        }
    }

    public void FreezeEnemy()
    {
        IsFrozen = true;

        timeFrezze = 3.0f;
    }

    public void UnfreezeEnemy()
    {
        if (timeFrezze > 0)
        {
            timeFrezze -= Time.deltaTime;
        }
        else
        {
            IsFrozen = false;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player1 player = collision.gameObject.GetComponent<Player1>();

            player.QuitarVida();

            Vector3 dir = transform.position - player.transform.position;
            dir.Normalize();

            transform.position += dir * empujeAlHacerHit;
        }
    }
}