using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private Slider _slider;

    void Start()
    {
        var audioManager = AudioManager.Instance;
        _slider = FindObjectOfType<Slider>();
        _slider.onValueChanged.AddListener((volume) => audioManager.SetVolume(volume));
    }

    public void OnDestroy()
    {
        _slider.onValueChanged.RemoveAllListeners();
    }

}
