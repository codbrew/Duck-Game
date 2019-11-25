using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitInfo : MonoBehaviour
{
    public string enemyName;
    public int enemyLvl;

    public int damage;

    public int maxLove = 100;
    public int currentLove;

    public GiftTypes.gift primaryGift;
    public GiftTypes.gift secondaryGift;
    public GiftTypes.gift dislikedGift;



    public bool TakeDamage(int dmg)
    {
        currentLove += dmg;

        if (currentLove >= 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void GiveGift(GiftTypes.gift givenGift)
    {
        if(givenGift == primaryGift)
        {
            TakeDamage(50);
        }
        if(givenGift == secondaryGift)
        {
            TakeDamage(25);
        }
        if(givenGift == dislikedGift)
        {
            TakeDamage(-25);
        }
    }
}