using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetSelect : MonoBehaviour
{
    public Image buttonImage;
    public Sprite[] planetImages;
    public GameObject[] planetObject;
    int counter = 0;

    public void NextPlanet()
    {
        planetObject[counter].SetActive(false);
        counter = counter + 1 == planetImages.Length ? 0 : counter + 1;
        planetObject[counter].SetActive(true);
        buttonImage.sprite = planetImages[counter];
    }
}
