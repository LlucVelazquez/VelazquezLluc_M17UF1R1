using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject menu;

    private void Update()
    {
        AudioClip clip = AudioManager.Instance.clipList[AudioClips.Music];
    }
}
