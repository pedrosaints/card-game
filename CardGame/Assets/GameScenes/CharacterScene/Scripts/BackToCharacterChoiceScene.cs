using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToCharacterChoiceScene : MonoBehaviour
{
    public string lastScene = "CharacterChoiceScene";
    public void BackToCharacterChoice()
    {
        // Retorna para a cena de escolha de personagem;

        SceneManager.LoadScene(lastScene);
    }
}
