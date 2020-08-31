using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggController : MonoBehaviour {
    public GameObject[] easterEggs;
    int index = 0;
    public void PlayEasterEgg()
    {
        easterEggs[index].SetActive(false);
        easterEggs[index].SetActive(true);
        index++;
        if (index == easterEggs.Length)
            index = 0;
    }
}
