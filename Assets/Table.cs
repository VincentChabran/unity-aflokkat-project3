using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public static Table Instance;


    public List<GameObject> targets = new List<GameObject>();
    private int cibleToucheeCount = 0;
    private bool victoireDejaDeclenchee = false;

    void Start()
    {
        Instance = this;
        GameManagerBis.Instance.DemarrerPartie();

    }

    public void NouvelleCibleTouche()
    {
        if (victoireDejaDeclenchee) return;

        cibleToucheeCount++;
        Debug.Log("Nombre de cibles touchées : " + cibleToucheeCount);

        GameManagerBis.Instance.AjouterPoint();



        if (cibleToucheeCount >= targets.Count)
        {
            Debug.Log("✅ Toutes les cibles ont été touchées !");
            victoireDejaDeclenchee = true;

            // Reset après un délai
            Invoke("ResetTable", 1.5f);
        }
    }

    private void ResetTable()
    {
        Debug.Log("🔄 La table est réinitialisée !");

        // Reset du compteur
        cibleToucheeCount = 0;
        victoireDejaDeclenchee = false;

        // Réactiver toutes les cibles
        foreach (GameObject cible in targets)
        {
            cible.SetActive(true);

            // Remettre à false le bool de CibleIndividuelle
            var scriptCible = cible.GetComponent<CibleIndividuelle>();
            if (scriptCible != null)
            {
                scriptCible.ResetCible();
            }
        }


    }
}
