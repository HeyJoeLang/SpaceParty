using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
public enum MUSIC_DIRECTION
{
    NEUTRAL, UP,DOWN
};
[System.Serializable]
public struct AnimationEvent
{
    public Animator animator;
    public string animState;
}
[System.Serializable]
public struct PlayableEvent
{
    public PlayableDirector playableDirector;
    public MUSIC_DIRECTION musicDirection;
    public List<AnimationEvent> anims;

    public void PlayGroup()
    {
        playableDirector.Play();
    }
}
public class TimelineController : MonoBehaviour {
    public TransitionMusic musicTrans;
    public List<PlayableEvent> events;
    bool moreTransitionsAvailanble;
    int index = 0;

    public bool MoreTransitionsAvailable()
    {
        return moreTransitionsAvailanble;
    }
    public void PlayNextEvent()
    {
        if (index >= 0 && index < events.Count)
        {
            if (events[index].playableDirector != null)
                events[index].PlayGroup();
            if (events[index].anims.Count > 0)
                StartCoroutine("PlayAnimsWithDelay");
            if (events[index].musicDirection == MUSIC_DIRECTION.UP)
                musicTrans.TransitionUp();
            if (events[index].musicDirection == MUSIC_DIRECTION.DOWN)
                musicTrans.TransitionDown();
            moreTransitionsAvailanble = true;
        }
        else
        {
            moreTransitionsAvailanble = false;
        }
        index++;
    }
    IEnumerator PlayAnimsWithDelay()
    {
        int currentIndex = index;
        yield return new WaitForSeconds((float)events[currentIndex].playableDirector.duration);
            for (int i = 0; i < events[currentIndex].anims.Count; i++)
                events[currentIndex].anims[i].animator.Play(events[currentIndex].anims[i].animState);
        }

}

