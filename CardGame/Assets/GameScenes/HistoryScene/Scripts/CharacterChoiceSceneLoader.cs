using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterChoiceSceneLoader : MonoBehaviour
{
    public Animator animScrollText;
    public string nextScene = "CharacterChoiceScene";
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

        SceneManager.LoadScene(nextScene);
    }

    public void LoadCharacterChoiceSceneWhenAnimationEnds()
    {
        // Carrega a cena de escolha de personagem caso a narração da história acabe.

        if (animScrollText.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            SceneManager.LoadScene(nextScene);
        }
    }



}
