using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public static VibrationManager instance;
    bool _isRing;
    public List<GameObject> _rings;   

    private void Awake()
    {
        instance = this;
        saveRing();
    }
    private void Start()
    {
        _isRing = PlayerPrefs.GetInt("RingOn", 1) == 1;
    }
    public void SetVibrationEnabled(bool enabled)
    {
        Vibration.SetVibrationEnabled(enabled);
        _isRing = !_isRing;
        PlayerPrefs.SetInt("RingOn",_isRing? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("Hoang");
    }
    public void Vibrate()
    {
        Vibration.Vibrate();
    }

    public  void Vibrate(long milliseconds)
    {
       Vibration.Vibrate(milliseconds); 
    }

    public  void Vibrate(long[] pattern, int repeat)
    {
        Vibration.Vibrate(pattern, repeat);
    }

    public void Cancel()
    {
        Vibration.Cancel();
    }
    void saveRing()
    {
        if (PlayerPrefs.GetInt("RingOn") ==0)
        {
            Vibration.SetVibrationEnabled(true);
            _rings[0].gameObject.SetActive(true);
            _rings[1].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("RingOn") == 1)
        {
            Vibration.SetVibrationEnabled(false);
            _rings[0].gameObject.SetActive(false);
            _rings[1].gameObject.SetActive(true);
        }
    }

}
