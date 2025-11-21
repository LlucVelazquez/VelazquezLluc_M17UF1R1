using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    private float timeBetweenBullets = 1f;
    private float initialTime = 1f;
    [SerializeField] private GameObject bullet;
    public Stack<GameObject> BulletsStack = new Stack<GameObject>();
    public Camera camera;
    private float _timer;
    public float bulletX;
    public float bulletY;
    void Start()
    {
        camera = Camera.main;
    }
    void Update()
    {
        _timer += Time.deltaTime;
        Vector2 viewportPoint = camera.WorldToViewportPoint(transform.position);
        if (viewportPoint.x >= 0f && viewportPoint.x <= 1f && viewportPoint.y >= 0f && viewportPoint.y <= 1f)
        {
            if (_timer >= timeBetweenBullets)
            {
                if (BulletsStack.Count == 0)
                {
                    AudioManager.Instance.PlaySource(AudioClips.Shoot);
                    GameObject bullett = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
                    bullett.GetComponent<BulletEnemy>().spawner = this;
                }
                else
                {
                    Pop();
                }
                _timer = 0;
            }
        }
        
        /*if (Time.time >= timeBetweenBullets)
        {
            AudioManager.Instance.PlaySource(AudioClips.Shoot);
            Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            timeBetweenBullets = initialTime + Time.time;
        }*/
    }
    public void Push(GameObject go)
    {
        BulletsStack.Push(go);
        go.SetActive(false);
    }
    public GameObject Pop()
    {
        GameObject go = BulletsStack.Pop();
        go.SetActive(true);
        go.transform.position = transform.position;
        go.transform.rotation = Quaternion.identity;
        go.GetComponent<Rigidbody2D>().linearVelocityY = bulletY;
        go.GetComponent<Rigidbody2D>().linearVelocityX = bulletX;
        return go;
    }
}
