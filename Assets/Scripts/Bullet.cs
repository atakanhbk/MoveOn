using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Merminin hýzý


    private void Start()
    {
        Invoke("DestroyBullet", 2f);
    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Tets");
        Destroy(other.gameObject);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

}