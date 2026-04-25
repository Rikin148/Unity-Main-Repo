using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth player;
    public Slider healthBar;
    public Image fillImage;
    public TextMeshProUGUI healText;

    void Start()
    {
        if (player != null)
        {
            player.OnHealthChanged += UpdateHealthBar;
            player.OnHealChanged += UpdateHealUI;
            healthBar.maxValue = player.maxHP;

            UpdateHealthBar(player.hp);
            UpdateHealUI(player.GetHealCharges());
        }
    }

    void UpdateHealthBar(int hp)
    {
        if (healthBar != null)
        {
            healthBar.value = hp;
        }

        if (fillImage != null && player != null)
        {
            float hpPercent = hp / (float)player.maxHP;

            if (hpPercent <= 0.3f)
            {
                fillImage.color = Color.red;
            }
            else
            {
                fillImage.color = Color.green;
            }
        }
    }

    void UpdateHealUI(int charges)
    {
        if (healText != null)
        {
            healText.text = "Q: " + charges;
        }
    }
}