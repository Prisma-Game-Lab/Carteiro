using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;    
    public Sound[] musicSounds, sfxSounds, sfxcSounds;
    public AudioSource musicSource, sfxSource, sfxcSource;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Valentin's bossa");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        
        if(s == null)
        {
            Debug.Log("Musica nao encontrada");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX nao encontrado");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PlaySFXC(string name)
    {
        Sound s = Array.Find(sfxcSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFXC nao encontrado");
        }
        else
        {
            sfxcSource.PlayOneShot(s.clip);
        }
    }

    public void StopAllSFX()
    {
        sfxSource.Stop();
        sfxcSource.Stop();
    }

    public void UIClick()
    {
        PlaySFX("CliqueUI");
    }

}
