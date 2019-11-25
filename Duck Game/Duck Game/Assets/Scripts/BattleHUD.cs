using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUDPlayer : MonoBehaviour
{
    public Text unitName;
    public Text unitLvl;

    public Slider confidenceSlider;

    // add in an experience slider

    public void Setup(PlayerUnitInfo playerUnitInfo)
    {
        unitName.text = playerUnitInfo.unitName;
        unitLvl.text = playerUnitInfo.unitLvl.ToString();

        confidenceSlider.maxValue = playerUnitInfo.maxConfidence;
        confidenceSlider.value = playerUnitInfo.currentConfidence;

        // set experience slider
    }

    public void SetConfidence(int confidence)
    {
        confidenceSlider.value = confidence;
    }

}
