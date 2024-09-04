using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject instructions;

    public void MudarCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("saiu do joguinho");
    }

    public void AbrirFecharInstrucions(bool ativarOuDesativar)
    {
        instructions.SetActive(ativarOuDesativar);
    }
}
