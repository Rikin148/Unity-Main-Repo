using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 50;
    public int hp;
    public Slider healthBar;
    public GameObject worldCanvas;
    private bool isDead = false; 

    void Start()
    {
        hp = maxHP;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHP;
            healthBar.value = hp;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; 
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            Die();
            return;
        }

        if (healthBar != null)
        {
            healthBar.value = hp;
        }
    }

    void Die()
    {
        isDead = true;

        if (healthBar != null)
        {
            healthBar.value = 0;
        }

        if (worldCanvas != null)
        {
            Destroy(worldCanvas);
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.EnemyDied();
        }

        Destroy(gameObject);
    }
}