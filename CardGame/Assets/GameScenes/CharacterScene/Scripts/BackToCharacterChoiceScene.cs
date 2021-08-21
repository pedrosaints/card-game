using UnityEngine;

public class BackToCharacterChoiceScene : MonoBehaviour
{
    public void BackToCharacterChoice()
    {
        // Retorna para a cena de escolha de personagem;

        Loader.Load(Loader.Scene.CharacterChoiceScene);
    }
}