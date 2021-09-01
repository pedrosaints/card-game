using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Player", menuName = "Player Model")]
public class Player : ScriptableObject
{
    public CharacterBaseModel character;
    public int currentHp;
    public int maxHp;
    public int level = 1;
    public int maxXP = 100;
    public int currentXp = 0;
    public int ID = 12345;
    private IList<Card> deck = CardList.Cards;


    public void InitializePlayer(CharacterBaseModel character)
    {
        this.character = character;
        currentHp      = this.character.charHp;
        maxHp          = this.character.charHp;
    }
    
    public void IncreaseStr() => character.charStr += 1;
    public void IncreaseSpr() => character.charSpr += 1;
    public void IncreaseDef() => character.charDef += 1;
    public void IncreaseSpd() => character.charSpd += 1;
    public void IncreaseHp() => character.charHp += 1;

    public void LevelUp() {
        IncreaseHp();
        IncreaseDef();
        IncreaseSpd();
        IncreaseSpr();
        IncreaseStr();
        level += 1;
        currentXp -= maxXP;
        maxXP += 100 * level;
        currentHp = character.charHp;
    }

    public void IncreaseXp(int xp)
    {
        if (currentXp + xp >= maxXP)
        {
            currentXp += xp;
            LevelUp();
        }
        else {
            currentXp += xp; 
        }
    }
    
    public void TakeDamage(int damage)
    {
        if(currentHp - damage <= 0)
            currentHp = 0;
        else
            currentHp -= damage;
    }

    public void UseCard(Card card) {
        
    }
    

}
