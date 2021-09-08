using UnityEngine;
using System.Collections.Generic;

public class Unit : MonoBehaviour
{

    public CharacterBaseModel character;

    public new string name;
    public int unitLevel;
    public int maxHp;
    public int curHp;
    public int str;
    public int spr;
    public int spd;
    public int def;
    public List<Card> deck;

    private void Awake()
    {
        LoadCharacterStatus();
    }

    public void LoadCharacterStatus()
    {
        if(character != null)
        {
            name  = character.charName;
            maxHp = character.charHp;
            curHp = character.charHp;
            str   = character.charStr;
            spr   = character.charSpr;
            spd   = character.charSpd;
            def   = character.charDef;
        }
    }

    public Sprite CharArt => character.charArt;

    public void ToJson()
    {

    }

}
