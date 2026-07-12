using UnityEngine;

public class Runadeempuje : MonoBehaviour
{
    public float PushDistance;

    private Transform enemy;

    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Enemy");

        if (obj != null)
            enemy = obj.transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PushEnemy();
            Destroy(gameObject);
        }
    }

    public void PushEnemy()
    {
        if (enemy == null)
            return;

        Vector3 dir = enemy.position - transform.position;
        dir.Normalize();

        enemy.position += dir * PushDistance;
    }
}