using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    public Animator animScrollText;
    public string nextScene = "ClassScene";
    private Button skipButton;

    public void Start()
    {
        animScrollText.speed = 1f;
        skipButton = GetComponent<Button>();
        skipButton.onClick.AddListener(LoadTributeSceneOnClick);
    }

    public void Update()
    {
        LoadTributeSceneWhenAnimationEnds();
    }

    public void LoadTributeSceneOnClick() 
    {
        SceneManager.LoadScene(nextScene);
    }

    public void LoadTributeSceneWhenAnimationEnds()
    {
        if (animScrollText.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            SceneManager.LoadScene(nextScene);
        }
    }



}
