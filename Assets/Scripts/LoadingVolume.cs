using UnityEngine;
using UnityEngine.Audio;

public class LoadingVolume : MonoBehaviour
{
    [SerializeField] AudioMixer Mixer;
    void Start()
    {
        float volume = PlayerPrefs.GetFloat("SavedMasterVolume");
        Mixer.SetFloat("MasterVol", Mathf.Log10(volume / 100) * 20f);
    }
}
