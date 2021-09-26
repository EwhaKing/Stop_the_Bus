using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour{

    public AudioMixer mixer;
    public Slider backSlider;
    public Slider effectSlider;
    public Image volumeMute;

    private float volume;
    
    public void Start(){
        if (backSlider != null) backSlider.value = data.background;
        if (effectSlider != null) effectSlider.value = data.effect;
    }

    public void backgroundControl(){
        volume = backSlider.value;
        data.background = volume;
        if (!data.mute){
            mixer.SetFloat("background",volume);
        }
    }

    public void effectControl(){
        
        volume = effectSlider.value;
        data.effect = volume;
            
        if (!data.mute){
            mixer.SetFloat("effect",volume);
        }
        
    }

    public void volumeControl(){
        if (data.mute){
            data.mute = !data.mute;
            volumeMute.sprite = Resources.Load<Sprite>("UI/음향 on");
            mixer.SetFloat("background",data.background);
            mixer.SetFloat("effect",data.effect);
        }
        else{
            data.mute = !data.mute;
            volumeMute.sprite = Resources.Load<Sprite>("UI/음향 off");
            mixer.SetFloat("background",-80f);
            mixer.SetFloat("effect",-80f);
        }
    }
}