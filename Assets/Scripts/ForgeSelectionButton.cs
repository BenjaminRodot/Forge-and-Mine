using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgeSelectionButton : MonoBehaviour
{
    public Weapon weapon;
    private Text txt;
    private GameObject forgeButton;

    void Awake()
    {
        txt = GameObject.Find("ForgeText").GetComponent<Text>();
        forgeButton = GameObject.Find("ForgeButton");
    }

    public void SetText()
    {

        txt.text = weapon.name.ToUpper()+"\n\n"+ weapon.nbItemNeededToForge.ToString().ToUpper() + "x " + weapon.itemNeededToForge.name.ToUpper();

        forgeButton.GetComponent<ForgeButton>().forgeMiniGame = GameObject.Find("ForgeMiniGame"+ weapon.typeOfWeapon);
        forgeButton.GetComponent<ForgeButton>().itemNeededToForge = weapon.itemNeededToForge;
        forgeButton.GetComponent<ForgeButton>().nbItemNeededToForge = weapon.nbItemNeededToForge;

    }
}