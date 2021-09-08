using UnityEngine;

public class QuestController : MonoBehaviour
{
    public void ToQuest()
    {
        Loader.Load(Loader.Scene.BattleScene);
    }
}
