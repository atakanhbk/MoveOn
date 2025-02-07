using UnityEngine;

public class Bullet : Weapon
{

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            MoveToEnemy();
        }
    }

    private void MoveToEnemy()
    {
        Vector2 direction = (Target.transform.position - transform.position).normalized;
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
