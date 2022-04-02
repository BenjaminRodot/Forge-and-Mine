using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{

    private float minPos = -5.5f;
    private float maxPos = 1.5f;
    private float vitesse = 3f;
    private int compteur = 4;
    private int score = 0;
    private Text RessourceMiniGameUI;

    public GameObject gameManager;
    private InventoryMenu inventoryMenu;

    // Start is called before the first frame update
    void Start()
    {
        RessourceMiniGameUI = GameObject.FindGameObjectWithTag("RessourceMiniGameUI").GetComponent<Text>();
        inventoryMenu = gameManager.GetComponent<InventoryMenu>();
        Vector2 newPos  = new Vector2();
        newPos.x = Random.Range(minPos, maxPos);
        newPos.y = 0;
        transform.localPosition = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(RunRessourceMiniGame.interact)
        {
            RessourceMiniGameUI.enabled = true;
            if(transform.localPosition.x >1.9 && vitesse>0)
            {
                vitesse=-vitesse;
            }
            if( transform.localPosition.x < -5.9 && vitesse<0)
            {
                vitesse=-vitesse;
            }
            transform.Translate(vitesse * Time.deltaTime,0,0);

            if(Input.GetKeyDown(KeyCode.E) && compteur>0)
            {
                if (compteur == 4)
                {
                    compteur--;
                    RessourceMiniGameUI.text = compteur.ToString() + "    times    left";
                }
                else if(transform.localPosition.x > -2.3 && transform.localPosition.x < -1.8)
                {
                    Debug.Log("Perfect +");
                    compteur--;
                    RessourceMiniGameUI.text=compteur.ToString()+"    times    left";
                    score+=3;
                } else if(transform.localPosition.x > -3.3 && transform.localPosition.x < -0.7)
                {
                    Debug.Log("Perfect ");
                    compteur--;
                    RessourceMiniGameUI.text=compteur.ToString()+"    times    left";
                    score+=2;
                } else if(transform.localPosition.x > -4.5 && transform.localPosition.x < 0.5)
                {
                    Debug.Log("Good");
                    compteur--;
                    RessourceMiniGameUI.text=compteur.ToString()+"    times    left";
                    score+=1;
                } else if(transform.localPosition.x > -6 && transform.localPosition.x < 2)
                {
                    Debug.Log("Fail");
                    compteur--;
                    RessourceMiniGameUI.text=compteur.ToString()+"    times    left";
                }
            }
            if(compteur==0){
                GameObject RessourceMiniGame = GameObject.Find("RessourceMiniGame");
                Vector2 defaultPos = new Vector2(-7,-15);
                RessourceMiniGame.transform.position = defaultPos;
                RunRessourceMiniGame.interact=false;
                RessourceMiniGameUI.enabled = false;
                compteur=4;
                Debug.Log(score);
                switch(score / 3)
                {
                    case 3:
                        Debug.Log("3");
                        inventoryMenu.AddItem(RunRessourceMiniGame.currentRareItemHarvest, 1);
                        break;
                    case 2:
                        Debug.Log("2");
                        inventoryMenu.AddItem(RunRessourceMiniGame.currentItemHarvest, 2);
                        break;
                    case 1:
                        Debug.Log("1");
                        inventoryMenu.AddItem(RunRessourceMiniGame.currentItemHarvest, 1);
                        break;
                }
                //SaveLoad.Save();

                score = 0;
            }
            if(!RunRessourceMiniGame.isInRange)
            {
               GameObject RessourceMiniGame = GameObject.Find("RessourceMiniGame");
                Vector2 defaultPos = new Vector2(-7,-15);
                RessourceMiniGame.transform.position = defaultPos;
                RunRessourceMiniGame.interact=false;
                RessourceMiniGameUI.enabled = false;
                compteur=4;
                score=0;
            }
        }
    }
}
