using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator fadeAnim;
    public float animSpeed = 0.3f;
    public float delayTime = 2.0f;

    public void Start()
    {
        fadeAnim.speed = animSpeed;
    }


    public void Update()
    {
        StartCoroutine(LoadTributeSceneWhenAnimationEnds(delayTime));
    }

    public IEnumerator LoadTributeSceneWhenAnimationEnds(float delayTime)
    {
        if (fadeAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            yield return new WaitForSeconds(delayTime);
            fadeAnim.Play("FadeOutAnim");
            yield return new WaitForSeconds(1.0f / fadeAnim.speed);
            SceneManager.LoadScene("ClassScene");
        }
    }
}
