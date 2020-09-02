using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TimelineController timelineCont;
    
    public bool CanKeepPlaying()
    {
        return timelineCont.MoreTransitionsAvailable();
    }
    public void Point()
    {
        timelineCont.PlayNextEvent();
    }
    public void SkipToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
