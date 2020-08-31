using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    Vector3 originalSize;
    private void Start()
    {
        originalSize = transform.localScale;

    }
    public void GrowSize()
    {
        transform.localScale = originalSize * 2;
    }
    public void ResetSize()
    {
        transform.localScale = originalSize;
    }
}
