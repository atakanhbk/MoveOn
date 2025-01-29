using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int enemySpeed;
    public GameObject player;
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to this enemy
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Call the method to move the enemy towards the player
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction from the enemy to the player
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Set the enemy's velocity to move towards the player
        rb.velocity = direction * enemySpeed;

        // If you just want to control the direction, you can change the position directly instead of using Rigidbody2D's velocity
        // transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}
