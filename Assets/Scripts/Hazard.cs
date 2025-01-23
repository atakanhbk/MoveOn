using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float fireRate = 1f; 
    public bool isActive = true; 

    public virtual void ActivateHazard()
    {
        // Engel aktif oldugunda yapýlacak iþlemler
        // Temel sýnýf olabilir
        Debug.Log("Hazard activated");
    }

    public virtual void DeactivateHazard()
    {
        // Engel pasif olduðunda yapýlacak iþlemler
        isActive = false;
        Debug.Log("Hazard deactivated");
    }
}
