using UnityEngine;
using UnityEngine.UI;

public class CharacterChoiceSceneLoader : MonoBehaviour
{
    public Animator animScrollText;
    private Button skipButton;

    public void Start()
    {
        animScrollText.speed = 1f;
        skipButton = GetComponent<Button>();
        skipButton.onClick.AddListener(LoadCharacterChoiceSceneOnClick);
    }

    public void Update()
    {
        LoadCharacterChoiceSceneWhenAnimationEnds();
    }

    public void LoadCharacterChoiceSceneOnClick() 
    {
        // Carrega a cena de escolha de personagem caso clique no botão. 
        
        Loader.Load(Loader.Scene.CharacterChoiceScene);
    }

    public void LoadCharacterChoiceSceneWhenAnimationEnds()
    {
        // Carrega a cena de escolha de personagem caso a narração da história acabe.

        if (animScrollText.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Loader.Load(Loader.Scene.CharacterChoiceScene);
        }
    }



}
