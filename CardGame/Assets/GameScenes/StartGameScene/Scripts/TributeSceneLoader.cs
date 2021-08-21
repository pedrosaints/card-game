using UnityEngine;

public class TributeSceneLoader : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            Loader.Load(Loader.Scene.TributeScene);
        }
    }
}
