using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthBar; // Reference to the health bar slider
    public Text healthPercentageText; // Reference to the health percentage text UI element

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        UpdateHealthText(); // Update the health text at the start
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);

        // Update the health bar and percentage text
        healthBar.value = currentHealth;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthText()
    {
        // Update the health percentage text dynamically
        float healthPercentage = ((float)currentHealth / maxHealth) * 100;
        healthPercentageText.text = "Health: " + Mathf.RoundToInt(healthPercentage) + "%";
    }

    void Die()
    {
        Debug.Log("Player Died!");
        // Add death logic here (e.g., respawn, end game, etc.)
    }
}
