using UnityEngine;

public class ToggleManualBreath : MonoBehaviour
{
    public BreathInput breathInput;
    private void OnEnable()
    {
        breathInput.SetTimelineFinished(true);
    }
    private void OnDisable()
    {
        breathInput.SetTimelineFinished(false);
    }
}
