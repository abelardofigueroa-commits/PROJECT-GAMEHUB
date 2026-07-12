using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float Speed;

    void Start()
    {

    }

    void Update()
    {
        if (Player != null)
        {
            FollowPlayer();
        }
    }

    public void FollowPlayer()
    {
        Vector3 TargetPosition = Player.position;

        TargetPosition.z = -50;

        Vector3 dir = TargetPosition - transform.position;

        transform.position += dir * Speed * Time.deltaTime;
    }
}