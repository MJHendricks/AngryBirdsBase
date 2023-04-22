using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 4f;

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
        Destroy(gameObject);

    }
}
