using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void MudarCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("saiu do joguinho");
    }
}
