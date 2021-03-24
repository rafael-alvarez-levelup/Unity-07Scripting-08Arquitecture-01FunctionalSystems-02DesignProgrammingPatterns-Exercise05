using UnityEngine;
using UnityEngine.UI;

public class HealthVisualController : MonoBehaviour, IObserver<HealthArgs>
{
    [SerializeField] private GameObject myCharacter;

    private ISubject<HealthArgs> healthSubject;
    private Slider mySlider;
    private Text myText;

    private void Awake()
    {
        mySlider = GetComponent<Slider>();
        myText = GetComponentInChildren<Text>();

        healthSubject = myCharacter.GetComponent<ISubject<HealthArgs>>();
    }

    private void OnEnable()
    {
        healthSubject.Add(this);
    }

    private void OnDisable()
    {
        healthSubject.Remove(this);
    }

    public void OnNotify(HealthArgs param)
    {
        SetHealth(param.health);
    }

    private void SetHealth(int currentHealth)
    {
        mySlider.value = currentHealth;
        myText.text = currentHealth.ToString();
    }
}