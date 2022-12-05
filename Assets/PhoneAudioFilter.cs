using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneAudioFilter : MonoBehaviour
{
    public AudioClip clip;

    [RangeAttribute(0, 20000)]
    public int lowFrequencyCutoff = 1000;

    [RangeAttribute(0, 20000)]
    public int highFrequencyCutoff = 5000;

    [RangeAttribute(0, 1)]
    public float distortionLevel = 0.6f;

    [RangeAttribute(0, 1)]
    public float volume = 0.6f;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        highPassFilter = gameObject.AddComponent<AudioHighPassFilter>();
        lowPassFilter = gameObject.AddComponent<AudioLowPassFilter>();
        distortion = gameObject.AddComponent<AudioDistortionFilter>();

        highPassFilter.cutoffFrequency = lowFrequencyCutoff;
        lowPassFilter.cutoffFrequency = highFrequencyCutoff;
        distortion.distortionLevel = distortionLevel;
        audioSource.volume = volume;
    }

    public void Play()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    private AudioSource audioSource;
    private AudioHighPassFilter highPassFilter;
    private AudioLowPassFilter lowPassFilter;
    private AudioDistortionFilter distortion;
}