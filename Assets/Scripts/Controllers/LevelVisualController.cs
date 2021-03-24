using UnityEngine;
using UnityEngine.UI;

public class LevelVisualController : MonoBehaviour, IObserver<LevelArgs>
{
    private Text myText;
    private ISubject<LevelArgs> subject;

    private void Awake()
    {
        myText = GetComponent<Text>();

        subject = LevelManager.Instance;
    }

    private void OnEnable()
    {
        subject.Add(this);
    }

    private void OnDisable()
    {
        subject.Remove(this);
    }

    public void OnNotify(LevelArgs param)
    {
        myText.text = param.level.ToString("00");
    }
}