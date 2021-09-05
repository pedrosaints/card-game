using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;


public enum BattleState
{
    PlayerTurn,
    EnemyTurn,
    EndTurn,
    Won,
    Lost
}

public enum AttackState
{
    PlayerAttack,
    EnemyAttack
}


public class BattleSystem : MonoBehaviour
{

    public Button endTurnButton;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerArea;
    public Transform enemyArea;

    public ResizableBar playerLifeBar;
    public ResizableBar enemyLifeBar;

    public Transform cardBattleArea;

    private BattleState battleState;
    private AttackState whoAttacks;

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
        endTurnButton.onClick.AddListener(() => {
            battleState = BattleState.EndTurn;
            GameTurn();
        });
        SetupBattle();
    }


    public void SetupBattle()
    {
        // SetupBattle carrega o jogador, inimigo, cartas do jogador, carrega a barra de hp do jogador e do inimigo e
        // verifica quem deve ser o primeiro a jogar, baseando-se no speed de cada um dos personagens e quem deve atacar primeiro.

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

        var firstAttack = ChooseFirstToAttack();
        whoAttacks = firstAttack == BattleState.EnemyTurn ? AttackState.EnemyAttack : AttackState.PlayerAttack;
         
        LoadPlayerCards();
        playerCardContainer.gameObject.AddComponent<CardAreaDrop>();
        playerCardContainer.GetComponent<CardAreaDrop>().maxChildrenNumber = maxCardsInHand;

        playerCardSlot = GameObject.Find("PlayerCardSlot").GetComponent<RectTransform>();
        playerCardSlot.gameObject.AddComponent<CardAreaDrop>();
        playerCardSlot.GetComponent<CardAreaDrop>().maxChildrenNumber = 1;

        enemyCardSlot = GameObject.Find("EnemyCardSlot").GetComponent<RectTransform>();

        enemyCards = enemy.GetComponent<Unit>().deck;
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

    public int CalcDamage(Unit attacker, Unit defender) => (attacker.str - defender.def) >= 0 ? attacker.str - defender.def : 0;
    public BattleState ChooseFirstToAttack()
    {
        // Verifica quem vai ser o primeiro a jogar.

        if (enemy.GetComponent<Unit>().spd >= player.GetComponent<Unit>().spd)
        {
            ChangeState(BattleState.EnemyTurn);
            return BattleState.EnemyTurn;
        }
        ChangeState(BattleState.EnemyTurn);
        return BattleState.EnemyTurn;
    }

    public void LoadEnemyCard()
    {
        // Carrega uma carta aleatória do inimigo no campo de batalha.
        var cardIndex = Random.Range(0, enemyCards.Count);
        var clone = Instantiate(cardPrefab, enemyCardSlot.transform);
        clone.GetComponent<CardRenderer>().Initialize(enemyCards[cardIndex]);
        Destroy(clone.GetComponent<DragAndDropCard>());
    }

    public void ChangeState(BattleState newState)
    {
        // Modifica o status do jogo.

        battleState = newState;

        switch (battleState)
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
            case BattleState.EndTurn:
                turnStatusText.text = "<color=#FF0000>Fim do turno!</color>";
                break;
        }
    }

    public void PlayerTurn()
    {
        // Aqui é onde deve ficar a lógica de como o jogador irá fazer suas jogadas.
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
        // Aqui é onde deve ficar a lógica de como o inimigo irá fazer suas jogadas.
        LoadEnemyCard();
        ChangeState(BattleState.PlayerTurn);
    }

    public void GameTurn()
    {
        // GameTurn é um método que por enquanto não está completo e está fazendo mais coisas do que deveria,
        // é aqui onde fica o controle dos turnos.
        // Ex: O primeiro a atacar é o jogador.
        //     Jogador usa uma carta -> Agora o turno é do inimigo.  
        //     Inimigo usa uma carta -> Agora é fim de turno.
        //     Jogador finaliza o turno clicando no botão de finalizar turno.


        if (battleState == BattleState.EnemyTurn)
        {
            EnemyTurn();
        }
        else if(battleState == BattleState.PlayerTurn)
        {
            PlayerTurn();
        } else if(battleState == BattleState.EndTurn)
        {
            if(whoAttacks == AttackState.EnemyAttack)
            {
                playerLifeBar.slider.value -= CalcDamage(enemy.GetComponent<Unit>(), player.GetComponent<Unit>());
                whoAttacks = AttackState.PlayerAttack;
            }

            if (whoAttacks == AttackState.PlayerAttack)
            {
                playerLifeBar.slider.value -= CalcDamage(player.GetComponent<Unit>(), enemy.GetComponent<Unit>());
                whoAttacks = AttackState.EnemyAttack;
            }

            DestroyCards();
            battleState = ChooseFirstToAttack();
        }
    }

    public void DestroyCards()
    {
        // DestroyCards deleta as cartas do inimigo e do jogador que estiverem em campo.

        if (playerCardSlot.childCount > 0 && battleState == BattleState.EndTurn)
        {
            currentPlayerCard = playerCardSlot.GetChild(0).gameObject;
            Destroy(currentPlayerCard);
        }

        if (enemyCardSlot.childCount > 0 && battleState == BattleState.EndTurn)
        {
            currentEnemyCard = enemyCardSlot.GetChild(0).gameObject;
            Destroy(currentEnemyCard);
        }
    }
   
}



