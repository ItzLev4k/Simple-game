using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    public MusicFader fader;

    public void PlayGame()
    {
        StartCoroutine(fader.FadeOut(1.5f));
        StartCoroutine(PlayAndLoad("SimpleGame"));
    }

    public void QuitGame()
    {
        StartCoroutine(PlayAndQuit());
    }

    private IEnumerator PlayAndLoad(string sceneName)
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator PlayAndQuit()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
        yield return new WaitForSeconds(2.3f);
        Application.Quit();
    }
}
