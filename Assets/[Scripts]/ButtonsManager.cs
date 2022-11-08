using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void InstructionsButton()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void CreditButton()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ExitButton()
    {
        
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
