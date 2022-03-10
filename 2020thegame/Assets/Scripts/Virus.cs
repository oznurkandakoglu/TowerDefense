
using System;
using UnityEngine;

public class Virus : MonoBehaviour
{

    public float speed = 10f;

    public int health = 100;

    public int value = 50;
    private Transform target;
    private int wavepointIndex = 0;


    void Start()
    {
        // HEDEF = İlk waypoint
        target = Waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (PlayerStats.Money <= 10000)
        {
            PlayerStats.Money += value;
        }
        Destroy(gameObject);
    }
    void Update()
    {
        //waypointe doğru ilerler
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);

        //waypointer vardığında GetNextWaypointi çağırır
        if (Vector3.Distance(transform.position,target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        // bundan bir sonraki waypointi alır ve target olarak belirler

        if (wavepointIndex >= Waypoints.points.Length - 1 )
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath ()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
