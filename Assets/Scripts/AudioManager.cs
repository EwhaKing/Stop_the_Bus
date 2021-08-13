using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour{

    public AudioMixer mixer;
    public Slider backSlider;
    public Slider effectSlider;

    private float volume;
    
    public void Start(){
        if (backSlider != null) backSlider.value = data.background;
        if (effectSlider != null) effectSlider.value = data.effect;
    }

    public void backgroundControl(){
        volume = backSlider.value;
        data.background = volume;
        
        mixer.SetFloat("background",volume);
        
    }

    public void effectControl(){
        volume = effectSlider.value;
        data.effect = volume;
        
        mixer.SetFloat("effect",volume);
        
    }
}