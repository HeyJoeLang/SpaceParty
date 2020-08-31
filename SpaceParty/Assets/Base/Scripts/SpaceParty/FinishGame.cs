using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour {
   
	void Start () {
        StartCoroutine("EndGame");
	}

	IEnumerator EndGame()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
        
    }
}
