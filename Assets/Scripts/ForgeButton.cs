using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgeButton : MonoBehaviour
{

    private Text interactUI;
    private GameObject forgeScreen;
    public GameObject forgeMiniGame;
    public Item itemNeededToForge;
    public int nbItemNeededToForge;

    private GameObject gameManager;
    private InventoryMenu inventoryMenu;

    // Start is called before the first frame update
    void Start()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        forgeScreen = GameObject.Find("ForgeScreen");
        gameManager = GameObject.Find("GameManager");
        inventoryMenu = gameManager.GetComponent<InventoryMenu>();
    }

    public void Click()
    {
        int nbItemToForge = inventoryMenu.GetNbItem(itemNeededToForge);

        if (nbItemToForge >= nbItemNeededToForge)
        {
            GameObject player = GameObject.Find("Player");
            Vector3 newPos = player.transform.position;
            newPos.y = newPos.y + 2.5f;
            newPos.x = newPos.x + 3.5f;
            newPos.z = 0;
            forgeMiniGame.transform.position = newPos;
            interactUI.enabled = false;
            forgeScreen.SetActive(false);
        }
        
    }
}
