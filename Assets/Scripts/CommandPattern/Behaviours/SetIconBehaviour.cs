using UnityEngine;
using UnityEngine.UI;

public class SetIconBehaviour : MonoBehaviour, ISetIcon
{
    private Image icon;

    private void Awake()
    {
        icon = GetComponent<Image>();
    }

    public void SetIcon(Sprite iconSprite)
    {
        icon.sprite = iconSprite;
    }
}