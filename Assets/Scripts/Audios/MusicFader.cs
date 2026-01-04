using System.Collections;
using UnityEngine;

public class MusicFader : MonoBehaviour
{
    public AudioSource musicSource;

    public IEnumerator FadeOut(float duration)
    {
        float startVolume = musicSource.volume;

        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        musicSource.Stop();
    }


    public IEnumerator FadeIn(float duration)
    {
        musicSource.volume = 0f;
        musicSource.Play();

        while (musicSource.volume < 1f)
        {
            musicSource.volume += Time.deltaTime / duration;
            yield return null;
        }

        musicSource.volume = 1f;
    }
}
