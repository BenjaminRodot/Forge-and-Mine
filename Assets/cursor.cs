using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursor : MonoBehaviour
{

    private float minPos = -5.5f;
    private float maxPos = 1.5f;
    private float vitesse = 3f;
    private int compteur = 4;
    private int score = 0;
    private Text miniGameUI;

    // Start is called before the first frame update
    void Start()
    {
        miniGameUI = GameObject.FindGameObjectWithTag("MiniGameUI").GetComponent<Text>();
        Vector2 newPos  = new Vector2();
        newPos.x = Random.Range(minPos, maxPos);
        newPos.y = 0;
        transform.localPosition = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(testObject.interact)
        {
            miniGameUI.enabled = true;
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
                if(transform.localPosition.x > -2.3 && transform.localPosition.x < -1.8)
                {
                    Debug.Log("Perfect +");
                    compteur--;
                    miniGameUI.text=compteur.ToString()+"    times    left";
                    score+=3;
                } else if(transform.localPosition.x > -3.3 && transform.localPosition.x < -0.7)
                {
                    Debug.Log("Perfect ");
                    compteur--;
                    miniGameUI.text=compteur.ToString()+"    times    left";
                    score+=2;
                } else if(transform.localPosition.x > -4.5 && transform.localPosition.x < 0.5)
                {
                    Debug.Log("Good");
                    compteur--;
                    miniGameUI.text=compteur.ToString()+"    times    left";
                    score+=1;
                } else if(transform.localPosition.x > -6 && transform.localPosition.x < 2)
                {
                    Debug.Log("Fail");
                    compteur--;
                    miniGameUI.text=compteur.ToString()+"    times    left";
                }
            }
            if(compteur==0){
                GameObject miniGame = GameObject.Find("miniGame");
                Vector2 defaultPos = new Vector2(-7,-15);
                miniGame.transform.position = defaultPos;
                testObject.interact=false;
                miniGameUI.enabled = false;
                compteur=4;
                Inventory.instance.AddCoins(score/3);
                score=0;
            }
            if(!testObject.isInRange)
            {
               GameObject miniGame = GameObject.Find("miniGame");
                Vector2 defaultPos = new Vector2(-7,-15);
                miniGame.transform.position = defaultPos;
                testObject.interact=false;
                miniGameUI.enabled = false;
                compteur=3;
                score=0;
            }
        }
    }
}
