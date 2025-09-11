using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Inicia o slider já com o volume atual
        volumeSlider.value = AudioListener.volume;
    }

    public void SetVolume(float volume)
    {
        // Controla o volume global do jogo em tempo real
        AudioListener.volume = volume;
    }
}