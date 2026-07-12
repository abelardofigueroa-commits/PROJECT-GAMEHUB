using UnityEngine;

public class fuentederunas : MonoBehaviour
{
    public GameObject[] RunePrefabs;

    private bool spawned = false;
    public float distanceSpawn = 40.0f;
    public float distanceToPlayer = 80.0f;

    public float timeToSpawn;

    const float Spawn = 3.0f;

    private GameObject Player1;

    public Animator Animator;

    private void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        timeToSpawn += Time.deltaTime;   


        if (timeToSpawn > Spawn)
        {
            SpawnRunes();
            timeToSpawn = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !spawned)
        {
            SpawnRunes();
            spawned = true;

            Player1 player1 = collision.GetComponent<Player1>();

            player1.fuentesActivadas += 1;

            Animator.SetBool("recolectado", true);
        }
    }

    public void SpawnRunes()
    {
        if (RunePrefabs == null || RunePrefabs.Length == 0 || Player1 == null)
        {
            //Debug.LogError("No hay runas asignadas.");
            return;
        }

        Vector3 myPos = transform.position;
        Vector3 player = Player1.transform.position;

        float distance = Vector3.Distance(myPos, player);

        if ( distance > distanceToPlayer)
        {
            return;
        }


        Vector3 dir = new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f),0.0f).normalized;

        int runa = Random.Range(0, 100);
        print(runa);
        if (runa > 50)
        {
            runa = 1;
        }
        else
        {
            runa = 0;
        }


        Instantiate(RunePrefabs[runa], transform.position + dir * distanceSpawn, Quaternion.identity);

        Debug.Log("Runa generada.");
    }
}