using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject inventoryUI;

    public List<Item> items = new List<Item>();
    public List<int> nbItems = new List<int>();
    public GameObject[] slots;

    // Start is called before the first frame update
    void Start()
    {
        DisplayItems();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        PlayerMovement.instance.enabled = false;
        inventoryUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        inventoryUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    private void DisplayItems()
    {
        for (int i = 0; i < items.Count(); i++)
        {
            slots[i].SetActive(true);

            //Update slots item Image
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].image;

            //Update slots count Text
            slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(1).GetComponent<Text>().text = nbItems[i].ToString();

        }
    }

    public void AddItem(Item item, int nbItem)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            nbItems.Add(nbItem);
        }
        else
        {
            for (int i = 0; i < items.Count(); i++)
            {
                if (items[i] == item)
                {
                    nbItems[i]+= nbItem;
                }
            }
        }
        DisplayItems();
    }

    public void RemoveItem(Item item, int nbItem)
    {
        if (!items.Contains(item))
        {
        }
        else
        {
            for (int i = 0; i < items.Count(); i++)
            {
                Debug.Log(items[i]);
                if (items[i] == item)
                {
                    if(nbItems[i] >= nbItem)
                    {
                        nbItems[i] -= nbItem;
                    }
                    else if(nbItems[i] == nbItem)
                    {
                        nbItems.RemoveAt(i);
                        items.RemoveAt(i);
                    }
                }
            }
        }
        DisplayItems();
    }

    public int GetNbItem(Item item)
    {
        int result = 0;

        for (int i = 0; i < items.Count(); i++)
        {
            if (items[i] == item)
            {
                result = nbItems[i];
            }
        }
        return result;
    }
}
