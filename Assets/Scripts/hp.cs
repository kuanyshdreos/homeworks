using UnityEngine;
using UnityEngine.UI;

public class SimpleHealthSystem : MonoBehaviour
{
    public Slider hp;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        float healthPercentage = currentHealth / maxHealth;
        hp.value = healthPercentage;
    }
}