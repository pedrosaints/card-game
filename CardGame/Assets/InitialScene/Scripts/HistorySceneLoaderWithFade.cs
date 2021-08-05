using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistorySceneLoaderWithFade : MonoBehaviour
{

    public void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            SceneManager.LoadScene("HistoryScene");
        }
    }
}
