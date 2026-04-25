using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    public float speed = 6f;
    public float lifeTime = 3f;
    private float timer;

    void OnEnable()
    {
        timer = lifeTime;
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            gameObject.SetActive(false); 
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) return;

        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(15);
            }

            gameObject.SetActive(false);
        }
    }
}