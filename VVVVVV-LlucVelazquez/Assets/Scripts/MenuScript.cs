using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject pauseMenu;
    private void Awake()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (menu)
            {
                StartGame();
            }
            else
            {
                Exit();
            }
        }
    }
    public void StartGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        pauseMenu.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
