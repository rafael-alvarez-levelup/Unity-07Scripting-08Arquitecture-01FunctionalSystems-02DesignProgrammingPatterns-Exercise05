using UnityEngine;

// TODO: Make with Scriptable Objects, in order to centralize the data.

public abstract class ActionBase : MonoBehaviour
{
    public Sprite Icon => icon;
    public int ActionPoints => actionPoints;

    public ICommand Command { get; protected set; }

    [SerializeField] private Sprite icon;

    // TODO: Enemy don't need this.
    [SerializeField] private int actionPoints;
}