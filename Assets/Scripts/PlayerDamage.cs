using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDamage : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    int DeathCounter = 0;

    public HealthBar healthBar;
    public PlayerMovement PlayerMovement;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        //Play hurt anim
        animator.SetTrigger("Hit");


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        DeathCounter++;
        animator.SetBool("Death", true);
        healthBar.Death(DeathCounter);
        PlayerMovement.Death(DeathCounter);
        Debug.Log("Enemy died");
    }
}
