using UnityEngine;

public class BulletShooter : Hazard
{
    public GameObject bulletPrefab; // Mermi prefab'ý
    public Transform firePoint; // Mermilerin çýkacaðý nokta

    private void Start()
    {
        InvokeRepeating("ShootBullet", 0f, fireRate); // Atýþ iþlemi sürekli olacak
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
