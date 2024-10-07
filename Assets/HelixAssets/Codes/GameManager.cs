using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    public event Action<int> onScoreChange;
    public event Action<int> onBestChange;

    private int scoreRegister = 0;
    private int bestRegister = 0;

    public int ScoreRegister
    {
        get => scoreRegister;
        set
        {
            scoreRegister = value;
            onScoreChange?.Invoke(scoreRegister);

            if (bestRegister < scoreRegister)
            {
                bestRegister = scoreRegister;
                onBestChange?.Invoke(bestRegister);

                PlayerPrefs.SetInt("BestScore", bestRegister);
            }
        }
    }

    public int BestRegister => bestRegister;

    private void Awake()
    {
        if (current == null)
        {
            current = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        bestRegister = PlayerPrefs.GetInt("BestScore");
    }
}
