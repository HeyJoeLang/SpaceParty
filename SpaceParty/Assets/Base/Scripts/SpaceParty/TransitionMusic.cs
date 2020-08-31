using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionMusic : MonoBehaviour {
    public AudioSource speaker;
    public AudioClip[] song1, song2;//, song3;
    public AudioClip[] clips;

    public int counter = -1;
    float currentSongMoment;

    private void Start()
    {
        clips = song1;
    }
    public void SetMusic(int index)
    {
        switch (index)
        {
            case 1: clips = song1; break;
            case 2: clips = song2; break;
        //    case 3: clips = song3; break;
            default: break;
        }
        //speaker.clip = clips[0];
    }
    public void TransitionUp()
    {
        speaker.volume = 1;
        if (counter < clips.Length-1)
            counter++;
        Transition();
    }
    public void TransitionDown()
    {
        if (counter > 0)
            counter--;
        Transition();
    }
    private void Transition()
    {
        currentSongMoment = speaker.time;
        speaker.clip = clips[counter];
        speaker.time = currentSongMoment;
        speaker.Play();
    }

	void Update () {/*
        if (Input.GetKeyDown(KeyCode.L))
            TransitionUp();
        if (Input.GetKeyDown(KeyCode.K))
            TransitionDown();
            */
    }
}
