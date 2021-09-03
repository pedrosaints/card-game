using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;


public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Won,
    Lost
}


public class BattleSystem : MonoBehaviour
{
    private int turn;

    public Button playerAttackButton;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerArea;
    public Transform enemyArea;

    public ResizableBar playerLifeBar;
    public ResizableBar enemyLifeBar;

    public Transform cardBattleArea;

    public BattleState state;

    private GameObject player;
    private GameObject enemy;

    private IList<Card> playerCards;
    private IList<Card> enemyCards;

    private GameObject currentEnemyCard;
    private GameObject currentPlayerCard;


    private RectTransform playerCardSlot;
    private RectTransform enemyCardSlot;

    public GameObject cardPrefab;
    public RectTransform playerCardContainer;
    public int maxCardsInHand = 4;

    public TMP_Text turnStatusText;



    public void Start()
    {
        playerAttackButton.onClick.AddListener(GameTurn);
        state = BattleState.Start;
        SetupBattle();
    }


    public void SetupBattle()
    {

        player = Instantiate(playerPrefab, playerArea);
        playerArea.GetComponent<Image>().sprite = player.GetComponent<Unit>().CharArt;
        playerLifeBar.ChangeColor(Color.green);
        playerLifeBar.slider.minValue = 0;
        playerLifeBar.slider.maxValue = player.GetComponent<Unit>().maxHp;
        playerLifeBar.slider.value = player.GetComponent<Unit>().maxHp;
        playerCards = player.GetComponent<Unit>().deck;


        enemy = Instantiate(enemyPrefab, enemyArea);
        enemyArea.GetComponent<Image>().sprite = enemy.GetComponent<Unit>().CharArt;
        enemyLifeBar.ChangeColor(Color.red);
        enemyLifeBar.slider.minValue = 0;
        enemyLifeBar.slider.maxValue = enemy.GetComponent<Unit>().maxHp;
        enemyLifeBar.slider.value = enemy.GetComponent<Unit>().maxHp;
        enemyCards = enemy.GetComponent<Unit>().deck;

        ChooseFirstToAttack();
        
        LoadPlayerCards();
        playerCardContainer.gameObject.AddComponent<CardAreaDrop>();
        playerCardContainer.GetComponent<CardAreaDrop>().maxChildrenNumber = maxCardsInHand;

        playerCardSlot = GameObject.Find("PlayerCardSlot").GetComponent<RectTransform>();
        playerCardSlot.gameObject.AddComponent<CardAreaDrop>();
        playerCardSlot.GetComponent<CardAreaDrop>().maxChildrenNumber = 1;

        enemyCardSlot = GameObject.Find("EnemyCardSlot").GetComponent<RectTransform>();

        enemyCards = enemy.GetComponent<Unit>().deck;

        turn = 1;

    }

    public void LoadPlayerCards()
    {
        // Carrega as cartas do jogador na sua mão.
        foreach (Card card in playerCards)
        {
            if (playerCardContainer.childCount >= maxCardsInHand) break;
            var clone = Instantiate(cardPrefab, playerCardContainer.transform);
            clone.GetComponent<CardRenderer>().Initialize(card);
            clone.AddComponent<DragAndDropCard>();
            clone.transform.localScale = new Vector3(1.5f, 1.5f, 0.0f);
        }
    }

    public bool PlayerDroppedCard() => playerCardSlot.childCount == 1;
    public bool PlayerHasCards() => playerCardContainer.childCount > 0;


    public void ChooseFirstToAttack()
    {
        // Verifica quem vai ser o primeiro a atacar.

        if (enemy.GetComponent<Unit>().spd >= player.GetComponent<Unit>().spd)
            ChangeState(BattleState.EnemyTurn);
        else
            ChangeState(BattleState.EnemyTurn);
    }

    public void LoadEnemyCard()
    {
        // Carrega uma carta aleatória do inimigo no campo de batalha.

        var clone = Instantiate(cardPrefab, enemyCardSlot.transform);
        clone.GetComponent<CardRenderer>().Initialize(enemyCards[Random.Range(0, enemyCards.Count)]);
        Destroy(clone.GetComponent<DragAndDropCard>());
    }

    public void ChangeState(BattleState newState)
    {
        // Modifica o status do jogo.

        state = newState;

        switch (state)
        {
            case BattleState.EnemyTurn:
                turnStatusText.text = "Vez do <color=#FF0000>inimigo</color>";
                break;
            case BattleState.PlayerTurn:
                turnStatusText.text = "Vez do <color=#00FF00>jogador</color>";
                break;
            case BattleState.Won:
                turnStatusText.text = "<color=#00FF00>Vitória!</color>";
                break;
            case BattleState.Lost:
                turnStatusText.text = "<color=#FF0000>Derrota!</color>";
                break;
        }
    }

    public void PlayerTurn()
    {
        if (PlayerHasCards())
        {
            if (PlayerDroppedCard())
            {
                ChangeState(BattleState.EnemyTurn);
            }
        }
        else
        {
            ChangeState(BattleState.EnemyTurn);
        }
    }

    public void EnemyTurn()
    {
        LoadEnemyCard();
        new WaitForSeconds(2);
        ChangeState(BattleState.PlayerTurn);
    }

    public void GameTurn()
    {
        if (state == BattleState.EnemyTurn)
        {
            EnemyTurn();
            PlayerTurn();
        }
        else if(state == BattleState.PlayerTurn)
        {
            PlayerTurn();
            EnemyTurn();
        }
    }

    
    public int CalcDamage(Unit attacker, Unit defender) => (attacker.str - defender.def) >= 0 ? attacker.str - defender.def : 0;
}



