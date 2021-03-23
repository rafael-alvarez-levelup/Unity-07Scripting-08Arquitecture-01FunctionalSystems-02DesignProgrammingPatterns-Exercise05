using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory<EnemyBase>
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private EnemyBase[] enemies;

    private Dictionary<int, EnemyBase> idToEnemy;

    private void Awake()
    {
        idToEnemy = enemies.ToDictionary(enemy => enemy.ID, enemy => enemy);
    }

    public EnemyBase Create(int id)
    {
        return Instantiate(idToEnemy[id], spawnPosition.position, spawnPosition.rotation);
    }

    public int[] GetIDs()
    {
        return idToEnemy.Keys.ToArray();
    }
}