using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MojoBar : MonoBehaviour {
    
    ProgressBarPro progressBar;
    public ParticleSystem finaleParticles;
    public ParticleSystem pointParticles;
    float percentagePerPoint = .2f;
    float totalPercent;
	void Start ()
    {
        totalPercent = 0;
        progressBar = GetComponentInChildren<ProgressBarPro>();
	}
    public void IncreaseMojo()
    {
        pointParticles.Play();
        totalPercent += percentagePerPoint;
        if(totalPercent <= 1f)
            progressBar.SetValue(totalPercent);
        if(totalPercent >= 1f)
        {
            GetComponent<Animator>().Play("Play");
            finaleParticles.Play();
        }
    }
}
