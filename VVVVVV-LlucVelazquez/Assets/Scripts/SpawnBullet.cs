using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    private float timeBetweenBullets = 0f;
    private float initialTime = 1f;
    [SerializeField] private GameObject bullet;
    public Stack<GameObject> BulletsStack = new Stack<GameObject>();
    void Start()
    {
        
    }
    void Update()
    {
        /*if(Time.time >= timeBetweenBullets)
        {
            if (BulletsStack.Count == 0)
            {
                GameObject bullett = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
                bullett.GetComponent<BulletEnemy>().spawner = this;
            }
            else
            {
                Pop();
            }
            timeBetweenBullets += initialTime;
        }*/
        if (Time.time >= timeBetweenBullets)
        {
            Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            timeBetweenBullets = initialTime + Time.time;
        }
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
        go.GetComponent<Rigidbody2D>().linearVelocityY = 4;
        return go;
    }
}
