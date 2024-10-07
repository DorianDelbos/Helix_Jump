using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

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

    private void EnablePause(bool enable)
    {
        Time.timeScale = (enable ? 0.0f : 1.0f);
        pauseMenu.SetActive(enable);
    }
}
