using UnityEngine;
using UnityEngine.UI;

public class SliderTextValue : MonoBehaviour {
    public Slider slider;
    public bool wholeNum = false;
    Text mText;
    void Start()
    {
        mText = GetComponent<Text>();
    }
    void Update()
    {
        mText.text = wholeNum ? slider.value.ToString("") : slider.value.ToString("0.0");
    }
}
