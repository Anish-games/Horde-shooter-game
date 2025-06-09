using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerHealthController : MonoBehaviour
{
    public static playerHealthController instance;

   public Slider healthSlider;
    public float maxHealth, currentHealth;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

    }

    public void TakeDamage(float Take_A_Damage)
    {
        currentHealth -= Take_A_Damage;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        healthSlider.value = currentHealth;
    }
}
