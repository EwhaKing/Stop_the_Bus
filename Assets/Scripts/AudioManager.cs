using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour{

    public AudioMixer mixer;
    public Slider backSlider;
    public Slider effectSlider;
    
    public void Start(){
        backSlider.value = data.background;
        effectSlider.value = data.effect;
    }

    public void backgroundControl(){
        float back = backSlider.value;
        data.background = back;
        mixer.SetFloat("background",back);
        
    }

    public void effectControl(){
        float eff = effectSlider.value;
        data.effect = eff;
        mixer.SetFloat("effect",eff);
        
    }
}