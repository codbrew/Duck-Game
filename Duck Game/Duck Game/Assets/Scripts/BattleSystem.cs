using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    public Sprite[] playerSprites;
    public Sprite[] enemySprites;
    public SpriteRenderer playerImage;
    public SpriteRenderer enemyImage;
    public AudioSource angryQuack;
    public AudioSource quack;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        expBar.value = playerUnit.currentXp;
    }

    IEnumerator SetupBattle()
    {
        playerUnit = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerUnitInfo>();

        enemyUnit = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyUnitInfo>();

        battleText.text = enemyUnit.enemyName + " looks uninterested...";

        playerHUD.Setup(playerUnit);
        enemyHUD.Setup(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        playerImage.sprite = playerSprites[1];
        PlayerTurn();
    }

    IEnumerator PlayerQuackAttack()
    {
        playerImage.sprite = playerSprites[2];
        bool isDead = enemyUnit.TakeDamage(playerUnit.attraction);

        enemyHUD.SetLove(enemyUnit.currentLove);
        battleText.text = "*Quacks*";
        expForAttack = playerUnit.earnedExperience / 2;
        currentEXP = expForAttack;
        quack.Play();
        yield return new WaitForSeconds(2f);
        playerImage.sprite = playerSprites[0];
        if(CalculateEXP())
        {
            playerImage.sprite = playerSprites[1];
            yield return new WaitForSeconds(4f);
        }
        if (isDead)
        {
            state = BattleState.WIN;
            EndBattle();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Overworld");

        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerRuffleFeathersAttack()
    {
        battleText.text = "*Ruffles Feathers*";
        playerImage.sprite = playerSprites[3];
        quack.Play();
        yield return new WaitForSeconds(1.5f);
        if (Random.Range(1,4) >= 3) { 
            bool isDead = enemyUnit.TakeDamage(playerUnit.rufflesFeathers);

            enemyHUD.SetLove(enemyUnit.currentLove);
            enemyImage.sprite = enemySprites[2];
            battleText.text = enemyUnit.enemyName + " can't stop looking at the cuteness!!!";
            yield return new WaitForSeconds(2f);

            expForAttack = playerUnit.rufflesFeathers / 2;
            currentEXP += expForAttack;
            if (CalculateEXP())
            {
                yield return new WaitForSeconds(2f);
            }
            if (isDead)
            {
                state = BattleState.WIN;
                EndBattle();
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene("Overworld");
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
        }
        else
        {
            enemyImage.sprite = enemySprites[1];
            angryQuack.Play();
            battleText.text = enemyUnit.enemyName + " looks insulted by the gesture";

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
            battleText.text = enemyUnit.enemyName + " quacks about their love of cake";

            yield return new WaitForSeconds(5f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }else if(randomAnswer == 2)
        {
            hint2.gameObject.SetActive(true);
            battleText.text = enemyUnit.enemyName + " quacks about their liking of cookies";

            yield return new WaitForSeconds(5f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        else if(randomAnswer == 3)
        {
            hint3.gameObject.SetActive(true);
            battleText.text = enemyUnit.enemyName + " fucking hates bread. Don't even bring it up ever again.";

            yield return new WaitForSeconds(5f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
        else if(randomAnswer == 4)
        {
            hint4.gameObject.SetActive(true);
            battleText.text = enemyUnit.enemyName + " enjoys swimming on the lake";

            yield return new WaitForSeconds(5f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        else if(randomAnswer == 5)
        {
            hint5.gameObject.SetActive(true);
            battleText.text = enemyUnit.enemyName + " thinks thicc boys are best boys";

            yield return new WaitForSeconds(5f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
   

    }

    IEnumerator EnemyTurn()
    {
        battleText.text = enemyUnit.enemyName + " glares at you";
        angryQuack.Play();
        playerImage.sprite = playerSprites[0];
        enemyImage.sprite = enemySprites[1];
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetConfidence(playerUnit.currentConfidence);

        yield return new WaitForSeconds(2f);
        playerImage.sprite = playerSprites[0];
        enemyImage.sprite = enemySprites[0];
        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
            yield return new WaitForSeconds(2f);
            
            SceneManager.LoadScene("Overworld");
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
            enemyImage.sprite = enemySprites[2];
            playerImage.sprite = playerSprites[3];
            battleText.text = "You did it!" + enemyUnit.enemyName + " has fallen for you!";
        }else if (state == BattleState.LOST)
        {
            enemyImage.sprite = enemySprites[1];
            enemyImage.transform.eulerAngles = new Vector3(0, 180, 0);
            playerImage.sprite = playerSprites[2];
            battleText.text = "Oh no! " + enemyUnit.enemyName + " has waddled away!";
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

    bool CalculateEXP()
    {
        playerUnit.currentXp += currentEXP;
        if (playerUnit.currentXp < 100)
        {
            expBar.value = playerUnit.currentXp;
            return false;
        }else 
        {
            playerUnit.currentXp -= 100;
            playerUnit.unitLvl++;
            playerUnit.maxConfidence += 5;
            playerUnit.attraction += 5;
            playerUnit.rufflesFeathers += 3;
            if (playerUnit.earnedExperience > 2)
                playerUnit.earnedExperience -= 2;
            else
                playerUnit.earnedExperience = 1;
            playerHUD.LevelUp(playerUnit);
            expBar.value = playerUnit.currentXp;
            battleText.text = playerUnit.unitName + " has leveled up. They are now level " + playerUnit.unitLvl;
            return true;
        }


    }
}
