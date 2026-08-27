using UnityEngine;

public class PathFinding : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    Transform[] wavePoints;


    int wavePointsIndex = 0;
    void Start()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        waveConfig = enemySpawner.GetCurrentWave();
        wavePoints = waveConfig.GetWavePoints();
        transform.position = waveConfig.GetStartingWavePoint().position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (wavePointsIndex < wavePoints.Length)
        {
            Vector3 targetPosition = wavePoints[wavePointsIndex].position;
            float moveDelta = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveDelta);
            if (transform.position == targetPosition)
            {
                wavePointsIndex++;
            }
        } else
        {
            Destroy(gameObject);
        }
    }
}
