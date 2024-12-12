using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI; 
    public GameObject player; 

    void Update()
    {
        if (player == null) 
        {
            ShowGameOverUI();
        }
    }

    
    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true); 
        Time.timeScale = 0f; 
    }

    
    public void RestartGame()
    {
        Debug.Log("RestartGame called. Time.timeScale to 1.");
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    
    public void QuitGame()
    {
        SceneManager.LoadScene("MainMen");
    }
}
