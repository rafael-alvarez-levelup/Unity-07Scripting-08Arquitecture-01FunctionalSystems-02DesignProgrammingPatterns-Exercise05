using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public int ID => id;

    [SerializeField] private int id;
}