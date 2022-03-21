using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunForgeMiniGame : MonoBehaviour
{

    private Text interactUI;
    public static bool isInRange;
    public static bool interact = false;
    public GameObject forgeMiniGame;
    //public Item itemNeededToForge;
    //public int nbItemNeededToForge;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange && !interact)
        {
            interact = true;
            Debug.Log(forgeMiniGame);
            GameObject player = GameObject.Find("Player");
            Vector3 newPos = player.transform.position;
            newPos.y = newPos.y + 2.5f;
            newPos.x = newPos.x + 3.5f;
            newPos.z = 0;
            forgeMiniGame.transform.position = newPos;
            interactUI.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !interact)
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }


}
