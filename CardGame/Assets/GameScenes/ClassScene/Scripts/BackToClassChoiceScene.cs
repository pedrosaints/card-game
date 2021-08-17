using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToClassChoiceScene : MonoBehaviour
{
    public string lastScene = "ClassChoiceScene";
    

    public void BackToClassChoice()
    {
        SceneManager.LoadScene(lastScene);
    }
}
