using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonManager : MonoBehaviour
{

    public UIDocument commencerUIDocument;
    public UIDocument quitterUIDocument;
    // Cette méthode doit être liée à l'événement OnClick du bouton dans l'éditeur Unity
    public void Start()
    {
        commencerUIDocument.rootVisualElement.Q<Button>("CommencerButton").clicked += () => Commencer();
        quitterUIDocument.rootVisualElement.Q<Button>("QuitterButton").clicked += () => Application.Quit();
    }

    public void Commencer()
    {
        Debug.Log("Commencer button clicked");
        SceneManager.LoadScene(1);
    }
}
