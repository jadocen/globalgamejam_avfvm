using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds
{
    Menu,
    Damaged,
    Die,
    Kick,
    Punch,
    Pickup,
    CoffeeMaker,
    B1A1,
    B1A2,
    B1A3,
    Choose,
    BossDefeat,
    B2A2,
    B2A32,
    YouWin
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
