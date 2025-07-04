using UnityEngine;

public class CibleIndividuelle : MonoBehaviour
{
    private bool dejaTouchee = false;

    private Vector3 positionInitiale;
    private Quaternion rotationInitiale;
    private float yInitial;

    // Valeur seuil à ajuster dans l'inspecteur
    public float seuilChute = 0.2f;

    // ✅ Nouvelle option : cette cible utilise Trigger ?
    public bool utiliserTrigger = false;

    private void Start()
    {
        // Sauvegarder position et rotation
        positionInitiale = transform.position;
        rotationInitiale = transform.rotation;

        // Hauteur initiale
        yInitial = transform.position.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (dejaTouchee) return;

        if (!utiliserTrigger && collision.gameObject.CompareTag("Balle"))
        {
            ValiderCible();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dejaTouchee) return;

        if (utiliserTrigger && other.CompareTag("Balle"))
        {
            ValiderCible();
        }
    }

    private void Update()
    {
        // Si la cible utilise gravité, on vérifie chute
        if (dejaTouchee) return;

        // ✅ Vérifier la chute SEULEMENT si on n'utilise pas le trigger ET si on a un Rigidbody
        if (!utiliserTrigger && GetComponent<Rigidbody>() != null)
        {
            if (transform.position.y < yInitial - seuilChute)
            {
                Debug.Log("✅ Cible tombée seule (hors collision) !");
                ValiderCible();
            }
        }

    }

    private void ValiderCible()
    {
        dejaTouchee = true;

        if (Table.Instance != null)
        {
            Table.Instance.NouvelleCibleTouche();
        }

        // Désactiver la cible
        gameObject.SetActive(false);
    }

    public void ResetCible()
    {
        dejaTouchee = false;

        // Réactiver
        gameObject.SetActive(true);

        // Remettre position et rotation
        transform.position = positionInitiale;
        transform.rotation = rotationInitiale;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
