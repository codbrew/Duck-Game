using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUDEnemy : MonoBehaviour
{
    public Text unitName;
    public Text unitLvl;

    public Slider loveMeter;

    public void Setup(EnemyUnitInfo enemyUnitInfo)
    {
        unitName.text = enemyUnitInfo.enemyName;
        unitLvl.text = enemyUnitInfo.enemyLvl.ToString();

        //loveMeter.maxValue = enemyUnitInfo.maxLove;
        loveMeter.value = enemyUnitInfo.currentLove;

       
    }

    public void SetLove(int love)
    {
        loveMeter.value = love;
    }
}
