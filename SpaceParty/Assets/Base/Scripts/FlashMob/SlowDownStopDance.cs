using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownStopDance : MonoBehaviour {

    public float TotalDanceTime;
	void Start () {
        StartCoroutine(StopDance());
	}
	
    IEnumerator StopDance()
    {
        yield return new WaitForSeconds(TotalDanceTime);
        GetComponent<Animator>().speed = 0;

    }
	// Update is called once per frame
	void Update () {
       // if (Input.GetKeyDown(KeyCode.Space))
        //    Debug.Log(Time.time);
		
	}
}
