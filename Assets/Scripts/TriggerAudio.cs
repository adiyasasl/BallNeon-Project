using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public static TriggerAudio Instance;
    [Header("Components")]
    [SerializeField]
    private AudioSource _audio;
    [SerializeField]
    private AudioClip _clip;

    void Awake()
    {
        if (Instance != null && Instance == this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void OnEnable()
    {
        StartAudio(_clip);
    }

    public void StartAudio(AudioClip clip)
    {
        if(clip != null)
            _audio.PlayOneShot(clip);
    }
}
