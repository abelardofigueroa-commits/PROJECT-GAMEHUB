using UnityEngine;

public class controlOrden : MonoBehaviour
{
    private GameObject Player1;
    public SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1 == null)
        {
            return;
        }

        if (Player1.transform.position.y > transform.position.y)
        {
            sprite.sortingOrder = 10;
        }
        else
        {
            sprite.sortingOrder = -1;
        }
    }
}
