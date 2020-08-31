using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {

    public string sceneName;
    Slider progressBar;
    public Animator cameraFade;

    void Start () {
        progressBar = GetComponent<Slider>();
        StartCoroutine(AsynchronousLoad(sceneName));
    }
	
    IEnumerator AsynchronousLoad(string scene)
    {
        yield return null;

        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            // [0, 0.9] > [0, 1]
            float progress = Mathf.Clamp01(ao.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");
            progressBar.value = progress;
            // Loading completed
            if (ao.progress == 0.9f)
            {
                cameraFade.Play("FadeOut");
                yield return new WaitForSeconds(2f);
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
