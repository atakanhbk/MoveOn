using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Vector2 spawnRange = new Vector2(10f, 10f);
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    float timer = 0;

 

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1.0f)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        // Get the player's position
        Vector2 playerPosition = player.transform.position;

        // Get the camera boundaries (for spawning outside the screen)
        Camera camera = Camera.main;
        float screenWidth = camera.orthographicSize * camera.aspect;
        float screenHeight = camera.orthographicSize;

        // Calculate spawn position outside of the screen
        Vector2 spawnPosition = Vector2.zero;

        // Calculate spawn position outside the screen, relative to the player
        // Spawn enemies outside of the screen by using the player's position as a reference
        if (Random.value > 0.5f)
            spawnPosition.x = Random.Range(playerPosition.x + screenWidth + spawnRange.x, playerPosition.x + screenWidth + spawnRange.x);
        else
            spawnPosition.x = Random.Range(playerPosition.x - screenWidth - spawnRange.x, playerPosition.x - screenWidth - spawnRange.x);

        if (Random.value > 0.5f)
            spawnPosition.y = Random.Range(playerPosition.y + screenHeight + spawnRange.y, playerPosition.y + screenHeight + spawnRange.y);
        else
            spawnPosition.y = Random.Range(playerPosition.y - screenHeight - spawnRange.y, playerPosition.y - screenHeight - spawnRange.y);

        GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);

        // ✅ Sahnedeki enemy nesnesine WeakEnemy scriptini alıp değer atıyoruz
        WeakEnemy weakEnemy = newEnemy.GetComponent<WeakEnemy>();
        weakEnemy.Player = player;
        
    }
}
