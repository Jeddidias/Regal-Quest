using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHeath;
    // Start is called before the first frame update
    void Start()
    {
        currentHeath = maxHealth;
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
