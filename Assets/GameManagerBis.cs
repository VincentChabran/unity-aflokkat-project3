using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation; // ajoute tout en haut si pas déjà présent


public class GameManagerBis : MonoBehaviour
{
    public static GameManagerBis Instance;

    public TMP_Text scoreText;
    public TMP_Text timerText;
    public GameObject boutonRejouer;

    private int score = 0;

    public float tempsInitial = 30f;
    private float tempsRestant;
    public bool partieEnCours = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Une autre instance de GameManagerBis existe déjà !");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
        tempsRestant = tempsInitial;
        UpdateTimerText();

        // Au début, désactiver le bouton
        if (boutonRejouer != null)
        {
            boutonRejouer.SetActive(false);
        }
    }

    private void Update()
    {
        if (partieEnCours && tempsRestant > 0)
        {
            tempsRestant -= Time.deltaTime;
            UpdateTimerText();

            if (tempsRestant <= 0)
            {
                tempsRestant = 0;
                FinDePartie();
            }
        }
    }

    public void DemarrerPartie()
    {
        partieEnCours = true;
        tempsRestant = tempsInitial;
        UpdateTimerText();
    }

    private void FinDePartie()
    {
        partieEnCours = false;
        Debug.Log("⏰ Temps écoulé ! Partie terminée.");

        // Trouver la caméra
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            ProjectileShooter shooterScript = mainCamera.GetComponent<ProjectileShooter>();
            if (shooterScript != null)
            {
                shooterScript.enabled = false;
            }
        }

        if (boutonRejouer != null)
        {
            boutonRejouer.SetActive(true);
        }
    }


    public void AjouterPoint()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score;
        }
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Temps : " + Mathf.CeilToInt(tempsRestant);
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }



    public void Rejouer()
    {
        Debug.Log("🔄 Rechargement de la scène...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
