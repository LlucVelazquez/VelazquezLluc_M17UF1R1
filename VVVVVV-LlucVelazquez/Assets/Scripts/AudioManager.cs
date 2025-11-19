using System.Collections.Generic;
using UnityEngine;
public enum AudioClips
{
    Walk,
    Booo,
    Death,
    Fly,
    Idle,
    Shoot,
    Enemy
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private List<AudioClip> _clip = new List<AudioClip>();
    public Dictionary<AudioClips, AudioClip> clipList = new Dictionary<AudioClips, AudioClip>();
    private void Awake()
    {
        Instance = this;
        clipList.Add(AudioClips.Walk, _clip[0]);
        clipList.Add(AudioClips.Booo, _clip[1]);
        clipList.Add(AudioClips.Death, _clip[2]);
        clipList.Add(AudioClips.Fly, _clip[3]);
        clipList.Add(AudioClips.Idle, _clip[4]);
        clipList.Add(AudioClips.Shoot, _clip[5]);
        clipList.Add(AudioClips.Enemy, _clip[6]);






    }
}