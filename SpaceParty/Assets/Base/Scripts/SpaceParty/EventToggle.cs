using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct ToggleableEvent
{
    public List<Animator> animators;
    public string animState;
    public MUSIC_DIRECTION musicDirection;
    private TransitionMusic musicTrans;
    void Start()
    {
        musicTrans = GameObject.Find("AudioController").GetComponent<TransitionMusic>();
    }
    public void PlayEvent()
    {
        if(animators.Count > 0)
            foreach (Animator anim in animators)
                anim.Play(animState);
        if (musicDirection == MUSIC_DIRECTION.UP)
            musicTrans.TransitionUp();
        if (musicDirection == MUSIC_DIRECTION.DOWN)
            musicTrans.TransitionDown();
    }
}

public class EventToggle : MonoBehaviour {

    public TransitionMusic musicTrans;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
