using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : Singleton<GamePlayManager>
{
    [SerializeField]
    private GameObject canvasPause;
    [SerializeField]
    private GameObject canvasEnd;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            canvasPause.SetActive(true);
        }
    }

    public void OnResume()
    {
        Time.timeScale = 1;
        canvasPause.SetActive(false);
    }

    public void LostAllLifes()
    {
        canvasEnd.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
