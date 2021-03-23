using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private IFactory<EnemyBase> enemyFactory;

    private void Awake()
    {
        enemyFactory = GetComponent<EnemyFactory>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int[] ids = enemyFactory.GetIDs();
            enemyFactory.Create(ids[Random.Range(0, ids.Length)]);
        }
    }
}