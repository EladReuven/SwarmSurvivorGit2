using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range (0.1f, 3f)]
    public float pitch;

    [Range (0f, 1f)]
    public float time;

    public bool loop;


    [HideInInspector]
    public AudioSource source;

    
    //public void LoopAt(Sound clip, float endTime, float startTime)
    //{
    //    if (clip.startTime >= endTime)
    //    {
    //        clip.startTime = startTime;
    //    }
    //}
}
