using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int enemySpeed;
    [SerializeField] GameObject player;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Player'a do�ru y�n hesapla
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Enemy'nin velocity de�erini ayarla
        rb.velocity = direction * enemySpeed;

        // E�er sadece y�n� kontrol etmek isterseniz, Rigidbody2D'nin velocity yerine position'� de�i�tirebilirsiniz.
        // transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}
