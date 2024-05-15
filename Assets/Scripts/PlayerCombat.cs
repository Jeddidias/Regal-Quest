using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int maxHealth = 100;
    int currentHeath;    
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    void Start()
    {
        currentHeath = maxHealth;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        // player to dettect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //player to damage enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);            
        }
    }
    void OnDrawGizmosSelected()
    {
        //if(attackPoint == null)
        //return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void TakeDamage(int damage)
    {
        currentHeath -= damage;

        if(currentHeath <= 0)
        {
            Die();
        }
    }
    // Update is called once per frame
    void Die()
    {
        animator.SetBool("IsDead", true);// Death animation

        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject,1);     
        this.enabled = false;
    }
}
