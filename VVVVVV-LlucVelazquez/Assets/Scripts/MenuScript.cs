using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    public void PauseGame()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }
}
