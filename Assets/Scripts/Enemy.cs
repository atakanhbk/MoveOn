using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyLevel;
    [SerializeField] private int enemyHealth;
    [SerializeField] private int enemyDamage;
    [SerializeField] private int enemySpeed;
    [SerializeField] private Image healthBar;
    private GameObject player;

    public int EnemyLevel { get => enemyLevel; set => enemyLevel = value; }

    public int EnemyHealth { get => enemyHealth; set => enemyHealth = value; }

    public int EnemyDamage { get => enemyDamage; set => enemyDamage = value; }

    public int EnemySpeed { get => enemySpeed; set => enemySpeed = value; }
   
    public GameObject Player { get => player; set => player = value; }
    public Image HealthBar { get => healthBar; set => healthBar = value; }

    public virtual void GetDamage(int amount)
    {
        enemyHealth -= amount;
        healthBar.fillAmount -= amount / 100f;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

 

}
