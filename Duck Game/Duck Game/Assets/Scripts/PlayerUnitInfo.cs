using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitInfo : MonoBehaviour
{
    public string unitName;
    public int unitLvl;

    public int attraction;
    public int rufflesFeathers;

    public int currentXp;
    public int maxLvlXp;

    public int maxConfidence;
    public int currentConfidence;

    public bool TakeDamage(int dmg)
    {
        currentConfidence -= dmg;

        if(currentConfidence <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
