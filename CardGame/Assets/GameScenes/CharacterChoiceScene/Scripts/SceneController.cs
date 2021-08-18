using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string nextScene = "CharacterScene";
    public void LoadCharacterScene(string charClass)
    {
        // Usa CharacterDataTransferor como uma ponte para enviar qual personagem foi escolhido para a próxima cena.
        // Em seguida, muda de cena.

        CharacterDataTransferor.charClass = charClass;
        SceneManager.LoadScene(nextScene);
    }

}
