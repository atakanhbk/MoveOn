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
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject pistol;
    [SerializeField] private float fireRate = 2.0f;
    private float minDistance = Mathf.Infinity;
    private float rotationSpeed = 20f;
    float timerForFire = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MovePlayer();

        FindNearestEnemy();

        RotatePlayer();
    }

    private void MovePlayer()
    {
        Vector2 moveDirection = movementJoystick.Direction;

        // Move Towards Joystick
        if (moveDirection != Vector2.zero)
        {
            rb.velocity = moveDirection * playerSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;  // Stop
        }
    }

    private void FindNearestEnemy()
    {
        minDistance = Mathf.Infinity;  // Recalculate distance;
   
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
            Fire();
        }   
    }

    private void RotatePlayer()
    {
        if (nearestEnemy != null)
        {
            // Rotate Toward Enemy
            Vector3 direction = nearestEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calculate angle
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), rotationSpeed);

        }
        else
        {
            // If there is no enemy, move forward
            Vector2 moveDirection = movementJoystick.Direction;
            if (moveDirection != Vector2.zero)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;  // Calculate angle
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

    private void Fire()
    {
  
       timerForFire += Time.deltaTime;

        if (timerForFire >= fireRate)
        {

            GameObject bulletObject = Instantiate(bullet, pistol.transform.position, Quaternion.identity);
            bulletObject.GetComponent<Bullet>().enemy = nearestEnemy;
            timerForFire = 0;
        }
 
    }
}
