using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TributeSceneLoader : MonoBehaviour
{
    public Animator animScrollText;
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
        SceneManager.LoadScene("TributeScene");
    }

    public void LoadTributeSceneWhenAnimationEnds()
    {
        if (animScrollText.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            SceneManager.LoadScene("TributeScene");
        }
    }



}
