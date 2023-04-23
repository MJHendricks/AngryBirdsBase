using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathfx;
    public float health = 4f;
    public static int EnemiesAlive = 0;

    void Start()
    {
        EnemiesAlive++;
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.relativeVelocity.magnitude > health)
        {
            Die();
        }

    }

    public void Die()
    {
        Instantiate(deathfx, transform.position, Quaternion.identity);
        EnemiesAlive--;
        if (EnemiesAlive <= 0)
        {
            Debug.Log("Level Complete");
        }
        Destroy(gameObject);

    }
}
