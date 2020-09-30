using UnityEngine;
using UnityEngine.SceneManagement;

public class GameNavigation : MonoBehaviour
{
    // Move to main Game view
    public void StartGame() { 
        SceneManager.LoadScene("GameView"); 
    }
    // Leave application
    public void Exit() { 
        Application.Quit(); 
    }
    // Move to menu
    public void BackToMenu() { 
        SceneManager.LoadScene("MenuView"); 
    }
}
