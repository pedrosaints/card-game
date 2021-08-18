
using UnityEngine;
using UnityEngine.UI;

public class CharacterSceneController : MonoBehaviour
{
    public Text charClassText;

    void Start()
    {
        SelectedClass();
    }


    public void SelectedClass()
    {

        if (CharacterDataTransferor.charClass == null) return;
        charClassText.text = CharacterDataTransferor.charClass;
    }

}
