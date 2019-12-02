using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState {START, PLAYERTURN, ENEMYTURN, WIN, LOST}

public class BattleSystem : MonoBehaviour
{
    public Text battleText;

    public BattleState state;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerSpawn;
    public Transform enemySpawn;

    public PlayerUnitInfo playerUnit;
    public EnemyUnitInfo enemyUnit;

    public BattleHUDPlayer playerHUD;
    public BattleHUDEnemy enemyHUD;

    public Text hint1;
    public Text hint2;
    public Text hint3;
    public Text hint4;
    public Text hint5;

    private string enemyName;
    private int randomAnswer;

    private int expForAttack;
    private int currentEXP;

    public Slider expBar;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
       GameObject playerGO = Instantiate(playerPrefab, playerSpawn);
        playerUnit = playerGO.GetComponent<PlayerUnitInfo>();
        
        GameObject enemyGO = Instantiate(enemyPrefab, enemySpawn);
        enemyUnit = enemyGO.GetComponent<EnemyUnitInfo>();

        battleText.text = enemyUnit.enemyName + " looks uninterested...";

        playerHUD.Setup(playerUnit);
        enemyHUD.Setup(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerQuackAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.attraction);

        enemyHUD.SetLove(enemyUnit.currentLove);
        battleText.text = "*Quacks*";

        expForAttack = playerUnit.attraction / 2;
        currentEXP += expForAttack;
        CalculateEXP();

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WIN;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerRuffleFeathersAttack()
    {
        if(Random.Range(1,4) >= 3) { 
            bool isDead = enemyUnit.TakeDamage(playerUnit.rufflesFeathers);

            enemyHUD.SetLove(enemyUnit.currentLove);
            battleText.text = "*Ruffles Feathers*";

            expForAttack = playerUnit.rufflesFeathers / 2;
            currentEXP += expForAttack;
            CalculateEXP();

            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                state = BattleState.WIN;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
        }
        else
        {
            
            battleText.text = "Thicc Duck laughs! Was not effective";

            yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator GiveGift()
    {

        yield return new WaitForSeconds(2f);
    }

    IEnumerator AskQuestion()
    {
        //Debug.Log("button works");

        randomAnswer = Random.Range(1, 5);

        if (randomAnswer == 1)
        {
            hint1.gameObject.SetActive(true);
            battleText.text = "Thicc Duck rambles on..";

            yield return new WaitForSeconds(2f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }else if(randomAnswer == 2)
        {
            hint2.gameObject.SetActive(true);
            battleText.text = "Thicc Duck rambles on..";

            yield return new WaitForSeconds(2f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        else if(randomAnswer == 3)
        {
            hint3.gameObject.SetActive(true);
            battleText.text = "Thicc Duck rambles on..";

            yield return new WaitForSeconds(2f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
        else if(randomAnswer == 4)
        {
            hint4.gameObject.SetActive(true);
            battleText.text = "Thicc Duck rambles on..";

            yield return new WaitForSeconds(2f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        else if(randomAnswer == 5)
        {
            hint5.gameObject.SetActive(true);
            battleText.text = "Thicc Duck rambles on..";

            yield return new WaitForSeconds(2f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
   

    }

    IEnumerator EnemyTurn()
    {
        battleText.text = enemyUnit.enemyName + " glares at you";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetConfidence(playerUnit.currentConfidence);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WIN)
        {
            battleText.text = "You did it! Thicc Duck has fallen for you!";
        }else if (state == BattleState.LOST)
        {
            battleText.text = "Oh no! Thicc Duck has waddled away!";
        }
    }

    void PlayerTurn()
    {
        battleText.text = "Choose an action:";
    }

    public void OnQuackButton()
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }
        else
        {
            StartCoroutine(PlayerQuackAttack());
        }
    }

    public void OnRuffleFeathersButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        else
        {
            StartCoroutine(PlayerRuffleFeathersAttack());
        }
    }

    public void OnGiveGiftButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        else
        {
            StartCoroutine(GiveGift());
        }
    }

    public void OnAskQuestionButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        else
        {
            StartCoroutine(AskQuestion());
        }
    }

    void CalculateEXP()
    {
        if(playerUnit.currentXp < 100)
        {
            playerUnit.currentXp = currentEXP;
            expBar.value = playerUnit.currentXp;
        }
        if (playerUnit.currentXp >= 100)
        {
            playerUnit.currentXp = 0;
            playerUnit.unitLvl++;
            LevelUp();
        }
        
    }

    void LevelUp()
    {
        playerUnit.attraction += 5;
        playerUnit.rufflesFeathers += 10;
    }
}
