using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] int bulletSpeed;


    // Update is called once per frame
    void Update()
    {
        if (enemy!= null)
        {
            MoveToEnemy();
        }
    }

    private void MoveToEnemy()
    {
        Vector2 direction = (enemy.transform.position - transform.position).normalized;
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }
}
