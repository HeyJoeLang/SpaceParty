using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlashMobDance : MonoBehaviour {
    public float flashMobTime;

	void Start () {
        StartCoroutine(LoadSpacePartyWhenFinished());
	}

	IEnumerator LoadSpacePartyWhenFinished()
    {
        yield return new WaitForSeconds(flashMobTime);
        SceneManager.LoadScene(0);
    }
}
