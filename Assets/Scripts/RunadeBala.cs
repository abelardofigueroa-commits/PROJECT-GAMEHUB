
using UnityEngine;

public class RunadeBala : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ALGO TOCO LA RUNA: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("RUNA RECOGIDA");

            Player1 player = other.GetComponent<Player1>();

            if (player != null)
            {
                Debug.Log("ENCONTRE PLAYER1");

                player.HasRune = true;
                player.Bullets = 1;

                Debug.Log("HASRUNE = " + player.HasRune);
                Debug.Log("BULLETS = " + player.Bullets);
            }
            else
            {
                Debug.Log("NO ENCONTRE PLAYER1");
            }

            Destroy(gameObject);
        }
    }
}