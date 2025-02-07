using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeakEnemy : Enemy
{
    private Rigidbody2D rb;
 
    void Start()
    {
   
        rb = GetComponent<Rigidbody2D>();
  
    }


    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (Player.transform.position - transform.position).normalized;
        rb.velocity = direction * EnemySpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            GetDamage(other.gameObject.GetComponent<Weapon>().Damage);
            other.gameObject.SetActive(false);
        }
    }

    public override void GetDamage(int amount)
    {
        base.GetDamage(amount);
    }

}