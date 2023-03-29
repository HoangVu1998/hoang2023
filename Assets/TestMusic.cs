using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMusic : MonoBehaviour
{
    private static TestMusic _instance;
    public static TestMusic Instance => _instance;
    public testSound[] sounds;
    public bool isPlaying = false;
    public string NameStop;

    public bool isMusic;
    public bool isEFC;

    public int Music = 0;
    public int EFC = 0;

    public List<GameObject> ButtonMusic;
    public List<GameObject> ButtonEFC;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        GetAudio();
        SaveSeting();
    }
    private void Start()
    {
        isMusic = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        isEFC = PlayerPrefs.GetInt("EFCOn", 1) == 1;
        isPlaying = false;
        Play("Theme");
       
    }
    private void GetAudio()
    {
        foreach (testSound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.volume = s.volume;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }
    public void Play(string _name)
    {
        foreach (var s in sounds)
            if (s.name == _name)
                s.source.Play();
    }
    public void playUpdate(string _name)
    {
        foreach (var s in sounds)
        {
            if (s.name == _name)
            {
                if (isPlaying)
                {
                    return;
                }
                s.source.Play();
                isPlaying = true;
                StartCoroutine(WaitForSFXToFinish(s.clip.length));
            }
        }
    }
    private IEnumerator WaitForSFXToFinish(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        isPlaying = false;
    }
    public void StopMusic()
    {
        foreach (var s in sounds)
        {
            if (s.name == "Theme")
            {
                s.source.mute = !s.source.mute;
            }
        }
        isMusic = !isMusic;
        PlayerPrefs.SetInt("MusicOn",isMusic? 1 : 0);
        PlayerPrefs.Save();
    }
    public void StopEFC()
    {
        foreach (var s in sounds)
        {
            if (s.name != "Theme")
            {
                s.source.mute = !s.source.mute;
            }
        }
        isEFC = !isEFC;
        PlayerPrefs.SetInt("EFCOn", isEFC ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void stop(string _name)
    {
        foreach (var s in sounds)
        {
            if (s.name == _name)
            {
                s.source.Stop();
            }
        }
    }
    void SaveSeting()
    {
        //save Music
        if (PlayerPrefs.GetInt("MusicOn") == 0)
        {
            foreach (var s in sounds)
            {
                if (s.name == "Theme")
                {
                    s.source.mute = false;
                }
            }
            ButtonMusic[0].SetActive(true);
            ButtonMusic[1].SetActive(false);  
        }
        if (PlayerPrefs.GetInt("MusicOn") == 1)
        {
            foreach (var s in sounds)
            {
                if (s.name == "Theme")
                {
                    s.source.mute = true;
                }
            }
            ButtonMusic[0].SetActive(false);
            ButtonMusic[1].SetActive(true);
        }
        //save EFC
        if (PlayerPrefs.GetInt("EFCOn") == 0)
        {
            foreach (var s in sounds)
            {
                if (s.name != "Theme")
                {
                    s.source.mute = false;
                }
            }
            ButtonEFC[0].SetActive(true);
            ButtonEFC[1].SetActive(false);
        }
        if (PlayerPrefs.GetInt("EFCOn") == 1)
        {
            foreach (var s in sounds)
            {
                if (s.name != "Theme")
                {
                    s.source.mute = true;
                }
            }
            ButtonEFC[0].SetActive(false);
            ButtonEFC[1].SetActive(true);
        }
    }
}