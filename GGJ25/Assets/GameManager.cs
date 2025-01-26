using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource buttonClickAudio;
    
    public void PlayGame()
    {
        buttonClickAudio.Play();
        SceneManager.LoadScene("Level1");
    }

    public void Credits()
    {
        buttonClickAudio.Play();
        SceneManager.LoadScene("Credts");
    }

    public void QuitGame()
    {
        buttonClickAudio.Play();
        Application.Quit();
    }
}
