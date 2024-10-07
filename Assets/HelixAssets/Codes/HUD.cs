using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTextMesh;
    [SerializeField] private TMP_Text bestTextMesh;

    [Header("Level bar")]
    [SerializeField] private TMP_Text leftLevelTextMesh;
    [SerializeField] private TMP_Text rightLevelTextMesh;
    [SerializeField] private Slider levelSlider;

    private Vector3 finishLinePosition;
    private Transform player;

    private void Start()
    {
        finishLinePosition = GameObject.FindWithTag("Finish").transform.position;
        player = GameObject.FindWithTag("Player").transform;

        UpdateScoreText(GameManager.current.ScoreRegister);
        UpdateBestText(GameManager.current.BestRegister);
    }

    private void Update()
    {
        float factor = player.transform.position.y / (finishLinePosition.y + 1.0f);
        levelSlider.value = factor;
    }

    private void OnEnable()
    {
        GameManager.current.onScoreChange += UpdateScoreText;
        GameManager.current.onBestChange += UpdateBestText;
        SceneManager.activeSceneChanged += UpdateLevelBar;
    }

    private void OnDisable()
    {
        GameManager.current.onScoreChange -= UpdateScoreText;
        GameManager.current.onBestChange -= UpdateBestText;
        SceneManager.activeSceneChanged -= UpdateLevelBar;
    }

    private void UpdateScoreText(int score)
    {
        scoreTextMesh.text = $"{score}";
    }

    private void UpdateBestText(int best)
    {
        bestTextMesh.text = $"BEST : {best}";
    }

    private void UpdateLevelBar(Scene from, Scene to)
    {
        int level = to.buildIndex;
        leftLevelTextMesh.text = $"{level + 1}";
        rightLevelTextMesh.text = $"{level + 2}";
    }
}
