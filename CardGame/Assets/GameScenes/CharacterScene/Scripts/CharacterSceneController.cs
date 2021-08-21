using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSceneController : MonoBehaviour
{
    public Image charArt;

    public TMP_Text charClassText;
    public TMP_Text charNameText;
    public TMP_Text charDescriptionText;
    public TMP_Text charCombatStyleText;

    public Slider strBar;
    public Slider defBar;
    public Slider sprBar;
    public Slider spdBar;
    public Slider hpBar;

    void Start()
    {
        GetSelectedCharacter();
    }


    public void GetSelectedCharacter()
    {
        if (CharacterDataTransferor.charModel == null) return;

        var charModel = CharacterDataTransferor.charModel;

        charArt.sprite = charModel.charArt;
        charClassText.text = charModel.charClass;
        charNameText.text = charModel.charName;
        charDescriptionText.text = charModel.charDescription;
        charCombatStyleText.text = charModel.charCombatStyle;

        strBar.value = charModel.charStr;
        defBar.value = charModel.charDef;
        sprBar.value = charModel.charSpr;
        spdBar.value = charModel.charSpd;
        hpBar.value = charModel.charHp;
    }

}
