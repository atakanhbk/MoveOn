using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    private List<GameObject> nearbyEnemies = new List<GameObject>();
    private GameObject nearestEnemy;
    private float minDistance = Mathf.Infinity;
    private float rotationSpeed = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Joystick ile hareket
        MovePlayer();

        // Nearest enemy kontrolü
        FindNearestEnemy();

        // Dönüþ kontrolü
        RotatePlayer();
    }

    private void MovePlayer()
    {
        Vector2 moveDirection = movementJoystick.Direction;

        // Joystick yönünde hareket
        if (moveDirection != Vector2.zero)
        {
            rb.velocity = moveDirection * playerSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;  // Joystick'e basýlmadýðýnda durma
        }
    }

    private void FindNearestEnemy()
    {
        minDistance = Mathf.Infinity;  // Mesafeyi baþtan baþlat
    

        if (nearbyEnemies.Count== 0)
        {
            nearestEnemy = null;
        }
        else
        {
            foreach (var enemy in nearbyEnemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = enemy;
                }
            }
        }

        
    }

    private void RotatePlayer()
    {
        if (nearestEnemy != null)
        {
            // Enemy'ye doðru dönme
            Vector3 direction = nearestEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Açý hesapla
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), rotationSpeed);
        }
        else
        {
            // Enemy yoksa, joystick yönüne doðru dönme
            Vector2 moveDirection = movementJoystick.Direction;
            if (moveDirection != Vector2.zero)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;  // Yön hesapla
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), rotationSpeed);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            nearbyEnemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            nearbyEnemies.Remove(collision.gameObject);
        }
    }
}
