using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public static Scene LastScene;
    public static Scene CurrentScene;
  
    public enum Scene
    {
        StartGameScene,
        TributeScene,
        HistoryScene,
        CharacterChoiceScene,
        CharacterScene,
        RouteScene,
        BattleScene,
    }

    public static void Load(Scene scene)
    {
        LastScene = CurrentScene;
        CurrentScene = scene;
        SceneManager.LoadScene(scene.ToString());
        CurrentStatus();
    }

    private static void CurrentStatus()
    {
        Debug.Log("curret scene = " + CurrentScene.ToString());
        Debug.Log("last scene = " + LastScene.ToString());
    }
}