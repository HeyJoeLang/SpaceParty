using UnityEngine;
using UnityEngine.UI;
using System.Collections;

#region GameStates
public enum INTERACTION_MODE
{
	AUTO,
	MANUAL
}
#endregion

public class GameController : MonoBehaviour
{
    #region ControllerVariables
    
    public INTERACTION_MODE interactionState = INTERACTION_MODE.MANUAL;
    public TimelineController timelineCont;
    public BreathInput breathInterface;

    #endregion

    #region EasterEggVariables

    private const float EASTER_EGG_HOLD_TIME = 1f;
    public EasterEggController easterEggCont;
    private float easterEggStartTime;
    #endregion

    #region InitializerFunctions
    public void StartGame()
    {
    }
#endregion
    #region GameStateFunctions

    public void SetGameStateAuto() { interactionState = INTERACTION_MODE.AUTO; }
	public void SetGameStateManual() { interactionState = INTERACTION_MODE.MANUAL; }

    #endregion
    #region ScoreFunctions

    public bool CanKeepPlaying()
    {
        return timelineCont.MoreTransitionsAvailable();
    }
    public void Point()
    {
        timelineCont.PlayNextEvent();
    }

    #endregion
    #region EasterEggFunctions

    public void EasterEggStartTimer()
    {
    	easterEggStartTime = Time.time;
    }
    public void EasterEggEndTimer()
    {
        if (Time.time - easterEggStartTime > EASTER_EGG_HOLD_TIME)
            easterEggCont.PlayEasterEgg();
        else
            breathInterface.Breath();
    }

#endregion


}
