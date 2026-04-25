using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 8f;
    public float lifeTime = 3f;
    public int baseDamage = 15;

    private float timer;
    private PlayerHealth playerHealth;

    void OnEnable()
    {
        timer = lifeTime; 

        if (playerHealth == null)
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            gameObject.SetActive(false); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                int damageToDeal = baseDamage;
                if (playerHealth != null)
                {
                    damageToDeal = playerHealth.GetOutgoingDamage(baseDamage);
                }

                enemy.TakeDamage(damageToDeal);
            }
            gameObject.SetActive(false); 
        }
    }
}