using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class options : MonoBehaviour
{
    [SerializeField] Slider SoundSlider;
    [SerializeField] AudioMixer Mixer;

    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume"));
    }

    public void SetVolume(float volume)
    {
        if (volume < 1)
        {
            volume = .001f;
        }
        RefreshSlider(volume);
        PlayerPrefs.SetFloat("SavedMasterVolume", volume);
        Mixer.SetFloat("MasterVol", Mathf.Log10(volume / 100) * 20f);
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(SoundSlider.value);
    }

    public void RefreshSlider(float volume)
    {
        SoundSlider.value = volume;
    }
}