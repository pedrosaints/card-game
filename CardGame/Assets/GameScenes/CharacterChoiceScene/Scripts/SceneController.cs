using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void LoadCharacterScene(CharacterBaseModel charModel)
    {
        // Usa CharacterDataTransferor como uma ponte para enviar qual personagem foi escolhido para a próxima cena.
        // Em seguida, muda de cena.

        CharacterDataTransferor.charModel = charModel;
        Loader.Load(Loader.Scene.CharacterScene);
    }
}