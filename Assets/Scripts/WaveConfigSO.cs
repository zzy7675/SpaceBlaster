using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemyMoveSpeed;
    [SerializeField] float timeBetweenEnemySpawns;
    [SerializeField] float enemySpawnVariance;
    [SerializeField] float minimumSpawnTime;


    public Transform GetStartingWavePoint()
    {
        return pathPrefab.GetChild(0);
    }
    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    public Transform[] GetWavePoints()
    {
        Transform[] wavePoints = new Transform[pathPrefab.childCount];

        for (int i = 0; i < pathPrefab.childCount; ++i)
        {
            wavePoints[i] = pathPrefab.GetChild(i);
        }
        return wavePoints;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Length;
    }

    public GameObject GetEnemyPrefabAt(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomEnemySpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - enemySpawnVariance, timeBetweenEnemySpawns + enemySpawnVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
