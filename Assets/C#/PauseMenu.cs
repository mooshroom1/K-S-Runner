using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    private bool isPaused = false;


    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            if (backgroundMusic != null)
                backgroundMusic.Pause();
        }
        else
        {
            Time.timeScale = 1;
            if (backgroundMusic != null)
                backgroundMusic.UnPause();
        }

    }
}
