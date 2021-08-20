using UnityEngine;

[CreateAssetMenu(fileName ="New Base Character", menuName = "Base Character")]
public class CharacterBaseModel : ScriptableObject
{
    public string charClass;
    public string charName;
    public string charDescription;
    public string charCombatStyle;
    public int charStr;
    public int charDef;
    public int charSpr;
    public int charSpd;
    public int charHp;
    public Sprite charArt;
}
