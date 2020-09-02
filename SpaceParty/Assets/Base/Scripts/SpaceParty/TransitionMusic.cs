using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionMusic : MonoBehaviour {
    public AudioSource speaker;
    public AudioClip[] song1, song2;
    public GameObject song1_image, song2_image;
    public AudioClip[] clips;
    public AudioClip defaultMusic;

    int songSelection = 1;
    int counter = 0;
    float currentSongTime;

    private void Start()
    {
        clips = song1;
    }
    public void ToggleMusicSelection()
    {
        songSelection = songSelection == 1 ? 2 : 1;
        switch (songSelection)
        {
            case 1:
                clips = song1;
                song1_image.SetActive(true);
                song2_image.SetActive(false);
                speaker.clip = song1[4];
                speaker.Play();
                break;
            case 2:
                clips = song2;
                song1_image.SetActive(false);
                song2_image.SetActive(true);
                speaker.clip = song2[4];
                speaker.Play();
                break;
            default: break;
        }
    }
    public void SetDefaultMusic()
    {
        speaker.clip = defaultMusic;
        speaker.Play();
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
        currentSongTime = speaker.time;
        speaker.clip = clips[counter];
        speaker.time = currentSongTime;
        speaker.Play();
    }

	void Update () {
    }
}
