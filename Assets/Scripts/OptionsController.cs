using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.6f;
    [SerializeField] int defaultDifficulty = 0;
    [SerializeField] Slider difficultySlider;
    MusicPlayer musicPlayer;

    void Start()
    {
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    void Update()
    {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        } else
        {
            Debug.LogWarning("No music player found!");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(Mathf.RoundToInt(difficultySlider.value));
        FindObjectOfType<LevelLoader>().LoadLevel("Start Screen");
    }

    public void SetDefaultValues()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }

}
