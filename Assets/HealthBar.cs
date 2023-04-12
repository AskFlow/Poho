using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;

    float health, maxHealth = 100;
    float lerpSpeed;

    private void Update()
    {
        if (health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
    }

    void HealthBarFiller()
    {
        fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, health / maxHealth, lerpSpeed);
    }

    public void SetMaxHealth(float newHealth)
    {
        maxHealth = newHealth;
        health = newHealth;
    }

    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }
}
