using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string nextScene = "CharacterScene";
    public void LoadCharacterScene(CharacterBaseModel charModel)
    {
        // Usa CharacterDataTransferor como uma ponte para enviar qual personagem foi escolhido para a próxima cena.
        // Em seguida, muda de cena.

        CharacterDataTransferor.charModel = charModel;
        SceneManager.LoadScene(nextScene);
    }

}
