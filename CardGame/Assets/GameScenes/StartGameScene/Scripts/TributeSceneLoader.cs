using UnityEngine;
using UnityEngine.SceneManagement;

public class TributeSceneLoader : MonoBehaviour
{
    public string nextScene = "TributeScene";

    public void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            SceneManager.LoadScene(nextScene);
            
        }
    }
}
