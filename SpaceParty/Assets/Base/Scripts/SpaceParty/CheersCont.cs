using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheersCont : MonoBehaviour {

    public AudioSource source;
    public List<AudioClip> encouragments;
    public List<AudioClip> discardAudio;
    public void PlayEncouragement()
    {
        if (encouragments.Count <= 0)
        {
            foreach (AudioClip clip in discardAudio)
                encouragments.Add(clip);
            discardAudio.Clear();
        }

        StartCoroutine("PlayAudio");
    }
    IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(Random.Range(.5f, 1.1f));
        int selection = Random.Range(0, encouragments.Count);
        source.PlayOneShot(encouragments[selection]);
        discardAudio.Add(encouragments[selection]);
        encouragments.RemoveAt(selection);

    }
}
