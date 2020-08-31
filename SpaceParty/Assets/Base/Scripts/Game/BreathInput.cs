using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BreathInput : MonoBehaviour
{
    public GameObject manualBreathButton;
    public GameController gameCont;
    private float cooldown = 4f, introTime = 5f;
    public Image interactionImage;

    public bool isCooledDown = true, isEnabled = false;

    private void Start()
    {
    }
    public void StartGame()
    {
        isEnabled = false;
        isCooledDown = true;
        StartCoroutine("UpdateManualInteractionImages");
    }
    
    public void ToggleBreath(bool toggle)
    {
        isEnabled = toggle;
    }

	void Update () 
	{
		if (gameCont.interactionState == INTERACTION_MODE.AUTO && gameCont.CanKeepPlaying()) {
			Breath ();
		}
	}

    public void Breath()
    {
        if (isCooledDown && isEnabled)
        {
            gameCont.Point();
            StartCoroutine("CoolDown");
        }
    }
    IEnumerator UpdateManualInteractionImages()
    {
        while(true)
        {
            yield return new WaitForSeconds(.25f);
            interactionImage.color = manualBreathButton.activeSelf ? Color.white : Color.grey;
            isEnabled = manualBreathButton.activeSelf;
        }
    }
    IEnumerator CoolDown()
    {
        isCooledDown = false;
        manualBreathButton.SetActive(false);
        yield return new WaitForSeconds(cooldown);
        isCooledDown = true;
        if (isEnabled)
            manualBreathButton.SetActive(true);
    }
    
}
