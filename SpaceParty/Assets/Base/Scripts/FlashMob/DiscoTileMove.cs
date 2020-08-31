using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum AXIS { X, Y}
public class DiscoTileMove : MonoBehaviour {
    public AXIS movementDirection = AXIS.X;
    public bool smooth;
    Material mat;
	void Start () {
        mat = GetComponent<Renderer>().material;
        StartCoroutine(JumpTile());
	}
    IEnumerator JumpTile()
    {
        Vector2 offset = movementDirection == AXIS.X ? new Vector2(.0005f, 0) : new Vector2(0,.5f);
        while (true)
        {
            if (smooth)
                yield return new WaitForEndOfFrame();
            else
                yield return new WaitForSeconds(1.5f);
            mat.mainTextureOffset += offset;

        }
    }
	void Update () {
		
	}
}
