using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassSceneLoader : MonoBehaviour
{
    public string nextScene = "ClassScene";

    public void ToClassScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
