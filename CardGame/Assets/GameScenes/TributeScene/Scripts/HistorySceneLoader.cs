using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistorySceneLoader : MonoBehaviour
{
    public Animator fadeAnim;
    public float animSpeed = 0.3f;
    public float delayTime = 1.8f;

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
            Loader.Load(Loader.Scene.HistoryScene);
        }
    }
}
