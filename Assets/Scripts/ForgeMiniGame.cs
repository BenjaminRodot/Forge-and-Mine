using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeMiniGame : MonoBehaviour
{
    private static bool start = false;
    public GameObject forgeMiniGame;
    public Item forgedItem;
    public Item itemNeededToForge;
    public int nbItemNeededToForge;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!RunForgeMiniGame.isInRange)
        {
            Vector2 defaultPos = new Vector2(-4, -15);
            forgeMiniGame.transform.position = defaultPos;
            RunForgeMiniGame.interact = false;
        }
    }

    void OnMouseOver()
    {
        
        if (start)
        {
            if (gameObject.name.Equals("Shape"))
            {
                start = false;
                Debug.Log("Perdu !!!");
                Vector2 defaultPos = new Vector2(-4, -15);
                forgeMiniGame.transform.position = defaultPos;
                RunForgeMiniGame.interact = false;
            }

            else if (gameObject.name.Equals("End"))
            {
                start = false;
                Inventory.instance.content.Add(forgedItem);
                for(int i = 0; i < nbItemNeededToForge; i++)
                {
                    Inventory.instance.content.Remove(itemNeededToForge);
                }
                Debug.Log("Gagne !!!");
                Vector2 defaultPos = new Vector2(-4, -15);
                forgeMiniGame.transform.position = defaultPos;
                RunForgeMiniGame.interact = false;
            }
        }
        if(!start)
        {
            if (gameObject.name.Equals("Start"))
            {
                start = true;
                Debug.Log("Start");
            }
        }
    }

    void OnMouseExit()
    {
            

    }
}
