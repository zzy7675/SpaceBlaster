using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore = 0;
    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }


    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void AddScore(int score)
    {
        currentScore += score;
        currentScore = Mathf.Clamp(currentScore, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
