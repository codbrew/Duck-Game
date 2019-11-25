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

    PlayerUnitInfo playerUnit;
    EnemyUnitInfo enemyUnit;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    public void SetupBattle()
    {
       GameObject playerGO = Instantiate(playerPrefab, playerSpawn);
        playerGO.GetComponent<PlayerUnitInfo>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemySpawn);
        enemyGO.GetComponent<EnemyUnitInfo>();

        battleText.text = enemyUnit.enemyName + "looks uninterested...";
    }
}
