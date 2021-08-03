using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToHistoryScene : MonoBehaviour
{

    [SerializeField] private string sceneName;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButton(0)) {
            SceneManager.LoadScene(sceneName);
        }
    }
}
