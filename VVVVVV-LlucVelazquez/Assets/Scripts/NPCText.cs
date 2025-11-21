using UnityEngine;

public class NPCText : MonoBehaviour
{
    public GameObject dialogue;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        dialogue.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogue.SetActive(false);
    }
}
