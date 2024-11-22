using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatScript : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDmg = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private bool blocking = false;
    public float blockCooldown = 1f;
    public float blockTime = 2f;
    public int blockAdv = 2;
    private bool canBlock = true;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Attack");
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetButtonDown("Block1"))
            {
                if (canBlock)
                {
                    Debug.Log("Block");
                    StartCoroutine(Block());
                }
            }
        }
        

    }

    void Attack()
    {
        //play attack anim
        animator.SetTrigger("Attack");
        //Detect enemies in range

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<PlayerCombatScript>().GetBlock())
            {
                enemy.GetComponent<PlayerDamage>().TakeDamage(attackDmg/blockAdv);
            }
            else
            {
                enemy.GetComponent<PlayerDamage>().TakeDamage(attackDmg);
            }
            
        }

    }
    public bool GetBlock()
    {
        return blocking;
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private IEnumerator Block()
    {
        canBlock = false;
        blocking = true;
        yield return new WaitForSeconds(blockTime);
        blocking = false;
        yield return new WaitForSeconds(blockCooldown);
        canBlock = true;
    }

}
