using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RunForgeMiniGame : MonoBehaviour
{

    private Text interactUI;
    public static bool isInRange;
    public static bool interact = false;
    public GameObject forgeMiniGame;
    public Item itemNeededToForge;
    public int nbItemNeededToForge;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        var listItemInventory = Inventory.instance.content.Where(Item => Item.id == itemNeededToForge.id).GroupBy(Item => Item.name);
        int nbItemToForge = 0;
        if (listItemInventory.Count() != 0)
        {
            nbItemToForge= listItemInventory.First().Count();
        }

        if (Input.GetKeyDown(KeyCode.E) && isInRange && !interact && nbItemToForge>=nbItemNeededToForge)
        {
            Debug.Log("Apres remove : " + Inventory.instance.content.Where(Item => Item.id == 10).GroupBy(Item => Item.name).First().Count());
            Debug.Log("Sword : " + Inventory.instance.content.Where(Item => Item.id == 20).GroupBy(Item => Item.name).Count());
            interact = true;
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
