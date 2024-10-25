using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public HomeSprite startingHome;
    public AudioMixer audioMixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat("volumenAudio")) * 20);
        audioMixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat("volumenMusic")) * 20);
        audioMixer.SetFloat("Voice", Mathf.Log10(PlayerPrefs.GetFloat("volumenVoice")) * 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
