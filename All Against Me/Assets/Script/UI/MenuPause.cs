using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    // [SerializeField] private GameObject gameCena;
    [SerializeField] private GameObject pauseCena;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!pauseCena.activeSelf)
            {
                Pause();
            }
            else
            {
                Continue();
            }
        }
    }

    public void Pause(){
        Time.timeScale = 0; // oq isso faz? e praq?
        Debug.Log("Menu Pausado");
        //gameCena.SetActive(false);
        pauseCena.SetActive(true);
    }

    public void Continue(){
        Time.timeScale = 1;
        Debug.Log("Menu Despausado");
        // gameCena.SetActive(true);
        pauseCena.SetActive(false);
    }

    public void SairJogo()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }

}
