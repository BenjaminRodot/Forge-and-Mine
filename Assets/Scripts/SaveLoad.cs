using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static Profil data = GameObject.Find("Profil").GetComponent<Profil>();

    public static string file = "profil_2";
    public static void Save()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        InventoryMenu inventoryMenu = gameManager.GetComponent<InventoryMenu>();
        string json = "";

        for (int i = 0; i < inventoryMenu.items.Count(); i++)
        {
            json += inventoryMenu.items[i].name+"\n"+ inventoryMenu.nbItems[i].ToString()+"\n";

        }

        WriteToFile("ProfilData/"+file+".txt", json);

    }

    public static void Load()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        InventoryMenu inventoryMenu = gameManager.GetComponent<InventoryMenu>();

        inventoryMenu.items.Clear();
        inventoryMenu.nbItems.Clear();

        int compteur = 0;
        Item tempItem;

        foreach (string jsonString in File.ReadLines("Assets/ProfilData/" + file + ".txt"))
        {
            tempItem = GameObject.Find("ListItem").GetComponent<testListItem>().GetItem(jsonString);
            int i = inventoryMenu.items.Count();

            if (compteur % 2 == 0)
            {
                tempItem = GameObject.Find("ListItem").GetComponent<testListItem>().GetItem(jsonString);
                inventoryMenu.items.Add(tempItem);
            }
            else
            {
                inventoryMenu.nbItems.Add(int.Parse(jsonString));
            }
            
            Debug.Log(jsonString);

            compteur++;
            
        }
        inventoryMenu.DisplayItems();
    }

    private static void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using(StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private static string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
            Debug.LogWarning("File not found");
        return "";
    }

    private static string GetFilePath(string fileName)
    {
        return Application.dataPath + "/" + fileName;
    }
}