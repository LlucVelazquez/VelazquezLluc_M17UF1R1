using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuConditionScript : MonoBehaviour
{
    public GameObject gameMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameMenu)
            {
                RestartGame();
            }
            else
            {
                Exit();
            }
        }
    }
    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }

}

