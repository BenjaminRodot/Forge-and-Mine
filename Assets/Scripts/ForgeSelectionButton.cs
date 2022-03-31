using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgeSelectionButton : MonoBehaviour
{
    public Weapon weapon;

    public void SetText()
    {
        Text txt = GameObject.Find("ForgeText").GetComponent<Text>();
        txt.text = weapon.nbItemNeededToForge.ToString().ToUpper() + "x " + weapon.itemNeededToForge.name.ToUpper();

        GameObject.Find("ForgeButton").GetComponent<ForgeMiniGame>().forgeMiniGame = GameObject.Find("ForgeMiniGame"+ weapon.typeOfWeapon);
        GameObject.Find("ForgeButton").GetComponent<ForgeMiniGame>().forgedItem = weapon;

    }
}