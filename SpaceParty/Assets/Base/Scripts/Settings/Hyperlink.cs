using UnityEngine;

public class Hyperlink : MonoBehaviour {
	
	public void OpenURL(string address)
	{
		Application.OpenURL (address);
	}
}
