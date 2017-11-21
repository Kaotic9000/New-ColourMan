using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public Slider slider;

    private static AudioController instance = null;
    public static AudioController Instance
    {
        get { return instance; }
    }

    public void Start()
    {
        slider.onValueChanged.AddListener(delegate { ValueChangedCheck(); });
    }

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ValueChangedCheck()
    {
        Debug.Log(slider.value);
    }
}
