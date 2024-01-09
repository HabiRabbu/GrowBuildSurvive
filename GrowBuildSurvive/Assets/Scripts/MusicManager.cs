using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private AudioSource audioSource;
    private float volume = .0f;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();

        volume = PlayerPrefs.GetFloat("musicVolume", .5f);

        audioSource.volume = volume;
    }

    public void IncreaseVolume() {
        volume += .1f;
        volume = Mathf.Clamp01(volume);
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void DecreaseVolume() {
        volume -= .1f;
        volume = Mathf.Clamp01(volume);
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public float GetVolume() {
        return volume;
    }
}
