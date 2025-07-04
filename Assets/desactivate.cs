using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class desactivate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void desactivateSpawn()
    {
        ObjectSpawner.Instance.enableSpawn = false; // Disable the ability to spawn objects   
    }


}
