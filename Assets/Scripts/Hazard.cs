using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float fireRate = 1f; 
    public bool isActive = true; 

    public virtual void ActivateHazard()
    {
        // Engel aktif oldugunda yap�lacak i�lemler
        // Temel s�n�f olabilir
        Debug.Log("Hazard activated");
    }

    public virtual void DeactivateHazard()
    {
        // Engel pasif oldu�unda yap�lacak i�lemler
        isActive = false;
        Debug.Log("Hazard deactivated");
    }
}
