using UnityEngine;
using UnityEngine.UI;

public class RunRessourceMiniGame : MonoBehaviour
{
    private Text interactUI;
    public static bool isInRange;
    public static bool interact = false;
    public Item itemHarvestable;
    public Item rareItemHarvestable;
    public static Item currentItemHarvest;
    public static Item currentRareItemHarvest;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange && !interact)
        {
            interact=true;
            GameObject ressourceMiniGame = GameObject.Find("RessourceMiniGame");
            GameObject player = GameObject.Find("Player");
            currentItemHarvest = itemHarvestable;
            currentRareItemHarvest = rareItemHarvestable;
            Vector3 newPos  = player.transform.position;
            newPos.y = newPos.y + 1.5f;
            newPos.x = newPos.x + 0.8f;
            newPos.z = 0;
            interactUI.enabled = false;
            ressourceMiniGame.transform.position = newPos;
            Text miniGameUI = GameObject.FindGameObjectWithTag("RessourceMiniGameUI").GetComponent<Text>();
            miniGameUI.text="3    times    left";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !interact)
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
            currentItemHarvest = null;
            currentRareItemHarvest = null;
        }
    }
}
