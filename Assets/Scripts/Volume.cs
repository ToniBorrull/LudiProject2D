using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider sliderMaster;
    public Slider sliderMusic;
    public Slider sliderVoice;

    public float sliderValue;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        sliderMaster.value = PlayerPrefs.GetFloat("volumenAudio");
        sliderMusic.value = PlayerPrefs.GetFloat("volumenMusic");
        sliderVoice.value = PlayerPrefs.GetFloat("volumenVoice");
    }

    // Update is called once per frame
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        audioMixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
    }

    public void ChangeSliderMusic(float valor)
    {
        sliderValue = valor;
        audioMixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("volumenMusic", sliderValue);
    }

    public void ChangeSliderVoice(float valor)
    {
        sliderValue = valor;
        audioMixer.SetFloat("Voice", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("volumenVoice", sliderValue);
    }
}
