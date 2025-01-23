using UnityEngine;

public class BulletShooter : Hazard
{
    public GameObject bulletPrefab; // Mermi prefab'�
    public Transform firePoint; // Mermilerin ��kaca�� nokta

    private void Start()
    {
        InvokeRepeating("ShootBullet", 0f, fireRate); // At�� i�lemi s�rekli olacak
    }

    public override void ActivateHazard()
    {
        base.ActivateHazard();
        Debug.Log("Bullet Shooter is active!");
    }

    private void ShootBullet()
    {
        if (isActive)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Mermiyi yarat
            Debug.Log("Bullet Fired!");
        }
    }
}
