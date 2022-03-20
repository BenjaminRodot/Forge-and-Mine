using UnityEngine;
using UnityEngine.UI;

public class testObject : MonoBehaviour
{
    private Text interactUI;
    public static bool isInRange;
    public static bool interact = false;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange && !interact)
        {
            interact=true;
            GameObject miniGame = GameObject.Find("miniGame");
            GameObject cam = GameObject.Find("Player");
            Vector3 newPos  = cam.transform.position;
            newPos.y = newPos.y + 1.5f;
            newPos.x = newPos.x + 0.8f;
            newPos.z = 0;
            interactUI.enabled = false;
            miniGame.transform.position = newPos;
            Text miniGameUI = GameObject.FindGameObjectWithTag("MiniGameUI").GetComponent<Text>();
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
        }
    }
}
