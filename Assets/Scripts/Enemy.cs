using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyLevel;
    [SerializeField] private int enemyHealth;
    [SerializeField] private int enemyDamage;
    [SerializeField] private int enemySpeed;
     private GameObject player;

    public int EnemyLevel { get => enemyLevel; set => enemyLevel = value; }

    public int EnemyHealth { get => enemyHealth; set => enemyHealth = value; }

    public int EnemyDamage { get => enemyDamage; set => enemyDamage = value; }

    public int EnemySpeed { get => enemySpeed; set => enemySpeed = value; }
   
    public GameObject Player { get => player; set => player = value; }

    public virtual void GetDamage(int amount)
    {
        enemyHealth -= amount;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

 

}
