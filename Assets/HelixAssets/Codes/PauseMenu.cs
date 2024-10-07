using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;

    void Start()
    {
        EnablePause(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EnablePause(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnablePause(true);
        }
    }

    public void EnablePause(bool enable)
    {
        Time.timeScale = (enable ? 0.0f : 1.0f);
        pauseMenu.SetActive(enable);
        pauseButton.SetActive(!enable);
    }
}
