using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Source")]
    [SerializeField] private AudioSource music, soundEffects;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } 
    }
    //reproduce efectos de sonido
    public void PlaySFX(AudioClip sound)
    {
        if (sound != null && soundEffects != null)
        {
            soundEffects.PlayOneShot(sound);
        }

    }
    //musica sin bucle
    public void PlayEndMusic(AudioClip song)
    {
        if (song == null || music == null) return;
        music.Stop();
        music.clip = song;
        music.Play();
        music.loop = false;
    }
    //musica en bucle
    public void PlayMusic(AudioClip song)
    {
        if (song == null || music == null) return;
        music.Stop();       
        music.clip = song;  
        music.Play();       
        music.loop = true;  
    }

    // silencia todo
    public void MuteAll()
    {
        if (music != null) music.volume = 0;
        if (soundEffects != null) soundEffects.volume = 0;
    }

    // Detener música
    public void StopMusic()
    {
        if (music != null) music.Stop();
    }

    // Ajustar volumen de música
    public void VolumeMusic(float newVolume)
    {
        if (music != null) music.volume = Mathf.Clamp01(newVolume);
    }

    // Ajustar volumen de efectos
    public void VolumeSFX(float newVolume)
    {
        if (soundEffects != null) soundEffects.volume = Mathf.Clamp01(newVolume);
    }


}

