using System.Collections;
using UnityEngine;

public class BGMBehaviour : MonoBehaviour
{
    [Header("Slowmotion Properties")]
    [SerializeField]
    private float fadeDuration = 0.5f;
    [SerializeField]
    private float targetPitch = 0.8f;
    [SerializeField]
    private float targetSpatialBend = 0.5f;

    private float defaultPitch;
    private float defaultSpatialBlend;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        defaultPitch = audioSource.pitch;
        defaultSpatialBlend = audioSource.spatialBlend;
    }

    public void StartSlowMo(bool start)
    {
        if (start)
        {
            StartCoroutine(StartFade(audioSource, fadeDuration, targetPitch, targetSpatialBend));
        }
        else
        {
            StartCoroutine(StartFade(audioSource, fadeDuration, defaultPitch, defaultSpatialBlend));
        }
    }

    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetPitch, float targetSpatialBend)
    {
        float currentTime = 0;
        float startPitch = audioSource.pitch;
        float startSpatialBend = audioSource.spatialBlend;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.pitch = Mathf.Lerp(startPitch, targetPitch, currentTime / duration);
            audioSource.spatialBlend = Mathf.Lerp(startSpatialBend, targetSpatialBend, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
