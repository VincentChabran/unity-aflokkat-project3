using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Camera playerCamera;
    public GameObject Table;


    // Fonction publique appelée par PlayerInput
    public void SpawnProjectile(InputAction.CallbackContext context)
    {
        if (!GameManagerBis.Instance.partieEnCours)
        {
            Debug.Log("⛔ Partie terminée, tir désactivé !");
            return;
        }

        if (context.performed)
        {
            Table = GameObject.Find("Table(Clone)");

            if (Table == null)
            {
                Debug.Log("Impossible de tirer : aucune table trouvée !");
                return;
            }

            GameObject projectile = Instantiate(projectilePrefab, playerCamera.transform.position, playerCamera.transform.rotation);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(playerCamera.transform.forward * 500f);
            }
        }
    }

}
