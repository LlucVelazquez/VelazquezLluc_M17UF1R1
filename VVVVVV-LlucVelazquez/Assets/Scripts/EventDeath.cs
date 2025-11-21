using UnityEngine;
using UnityEngine.InputSystem;

public class EventDeath : MonoBehaviour
{
    public GameObject gameOverMenu;
    private void OnEnable()
    {
        Player.death += GameOver;
    }
    private void OnDisable()
    {
        Player.death -= GameOver;
    }
    public void GameOver()
    {
        AudioManager.Instance.PlaySource(AudioClips.Death);
        gameOverMenu.SetActive(true);
    }
}
