using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MojoTimelineInteraction : MonoBehaviour {
    public MojoBar mojoBar;

    public void OnEnable()
    {
        mojoBar.IncreaseMojo();
    }
}
