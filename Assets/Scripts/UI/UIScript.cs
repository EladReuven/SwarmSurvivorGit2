using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI lvlText;
    public TextMeshProUGUI pointsText;


    private void Update()
    {
        if(PlayerCombatParameters.instance.hp > 6)
        {
            hpText.color = Color.white;
            hpText.text = "HP: " + PlayerCombatParameters.instance.hp;
        }
        else if(PlayerCombatParameters.instance.hp <= 6 && PlayerCombatParameters.instance.hp > 3)
        {
            hpText.color = Color.yellow;
            hpText.text = "HP: " + PlayerCombatParameters.instance.hp;
        }
        else
        {
            hpText.color = Color.red;
            hpText.text = "HP: " + PlayerCombatParameters.instance.hp;
        }

        lvlText.text = "Level: " + PlayerCombatParameters.instance.level;
        
        pointsText.text = "Points: " + Score.instance.points;
    }
}
