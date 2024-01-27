using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds
{
    Damaged,
    Die,
    Kick,
    Punch
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource audioSource;

    private List<AudioClip> sounds = new List<AudioClip>();

    public void Awake()
    {
        instance = this;

        foreach (string a in System.Enum.GetNames(typeof(Sounds)))
        {
            sounds.Add(Resources.Load<AudioClip>("sound/" + a));
        }
    }

    public void PlaySound(Sounds sound)
    {
        audioSource.PlayOneShot(sounds[(int)sound]);
    }
}
