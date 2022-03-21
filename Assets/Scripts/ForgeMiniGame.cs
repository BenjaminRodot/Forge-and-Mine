using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeMiniGame : MonoBehaviour
{
    private static bool start = false;
    private static bool end = false;
    public GameObject forgeMiniGame;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            Vector2 defaultPos = new Vector2(-4, -15);
            forgeMiniGame.transform.position = defaultPos;
            RunForgeMiniGame.interact = false;
            end = false;
        }
        if (!RunForgeMiniGame.isInRange)
        {
            Vector2 defaultPos = new Vector2(-4, -15);
            forgeMiniGame.transform.position = defaultPos;
            RunForgeMiniGame.interact = false;
            end = false;
        }
    }

    void OnMouseOver()
    {
        
        if (start)
        {
            if (gameObject.name.Equals("Shape"))
            {
                start = false;
                end = true;
                Debug.Log("Perdu !!!");
            }

            else if (gameObject.name.Equals("End"))
            {
                start = false;
                end = true;
                Debug.Log("Gagne !!!");
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
