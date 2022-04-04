using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfilSelector : MonoBehaviour
{

    public void SelectProfil()
    {
        SaveLoad.file = "profil_" + this.gameObject.transform.GetChild(0).GetComponent<Text>().text;
        Debug.Log(SaveLoad.file);
        SceneManager.LoadScene("Level01");
    }
}
