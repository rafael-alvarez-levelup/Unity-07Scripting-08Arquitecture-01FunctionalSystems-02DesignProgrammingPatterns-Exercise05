using UnityEngine;
using UnityEngine.UI;

public class BarActionBehaviour : MonoBehaviour, IBarAction
{
    private Slider mySlider;
    private Text myText;

    private void Awake()
    {
        mySlider = GetComponent<Slider>();

        myText = GetComponentInChildren<Text>();
    }

    public void SetActionPoints(int totalActionPoints)
    {
        float current = mySlider.maxValue - totalActionPoints;

        mySlider.value = current;
        myText.text = $"{current} / {mySlider.maxValue}";
    }
}