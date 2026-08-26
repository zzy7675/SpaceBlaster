using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemyMoveSpeed;


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
}
