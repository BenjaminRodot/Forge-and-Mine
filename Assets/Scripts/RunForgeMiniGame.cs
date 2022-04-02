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
    private GameObject forgeScreen;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        forgeScreen = GameObject.Find("ForgeScreen");
        forgeScreen.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isInRange && !interact)
        {
            Debug.Log("Test");
            interact = true;
            forgeScreen.SetActive(true);
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
            forgeScreen.SetActive(false);
            isInRange = false;
        }
    }


}
