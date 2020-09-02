using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BreathInput : MonoBehaviour
{
    public GameController gameCont;
    private float cooldown = 4f, introTime = 5f;
    public Image interactionImage;
    public Sprite timerImage, manualImage;

    public bool isCooledDown = true, isTimelineFinished = false;
    
    enum INPUT_MODE
    {
        TIMER,
        MANUAL
    }
    INPUT_MODE input_mode = INPUT_MODE.MANUAL;
    public void StartGame()
    {
        isCooledDown = false;
        StartCoroutine("CoolDown");
        StartCoroutine("UpdateManualIndicator");
    }

    public void ToggleInputMode()
    {
        input_mode = input_mode == INPUT_MODE.TIMER ? INPUT_MODE.MANUAL : INPUT_MODE.TIMER;
        switch (input_mode)
        {
            case INPUT_MODE.TIMER:
                interactionImage.sprite = timerImage;
                break;
            case INPUT_MODE.MANUAL:
                interactionImage.sprite = manualImage;
                break;
        }
    }
    void Update () 
	{
		if (input_mode == INPUT_MODE.TIMER && gameCont.CanKeepPlaying()) {
			Breath ();
		}
	}
    public void SetTimelineFinished(bool isFinished)
    {
        isTimelineFinished = isFinished;
    }
    public void Breath()
    {
        if (isCooledDown && isTimelineFinished)
        {
            gameCont.Point();
            StartCoroutine("CoolDown");
        }
    }
    IEnumerator UpdateManualIndicator()
    {
        while(true)
        {
            yield return new WaitForSeconds(.25f);
            interactionImage.color = isTimelineFinished ? Color.white : Color.grey;
        }
    }
    IEnumerator CoolDown()
    {
        isCooledDown = false;
        yield return new WaitForSeconds(cooldown);
        isCooledDown = true;
    }
    
}
