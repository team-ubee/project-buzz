using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public AudioClip[] Intro;
    public AudioClip[] Teaser;
    public AudioClip[] Trailer;
    public AudioClip[] Hardship;
    public AudioClip[] Finish;

    private List<AudioClip> _Clips = new List<AudioClip>();

    public int NextToPlay = 0;

    public void Awake()
    {
        foreach(var clip in Intro) { _Clips.Add(clip); }
        foreach (var clip in Teaser) { _Clips.Add(clip); }
        foreach (var clip in Trailer) { _Clips.Add(clip); }
        foreach (var clip in Hardship) { _Clips.Add(clip); }
        foreach (var clip in Finish) { _Clips.Add(clip); }
    }
}
