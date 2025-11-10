using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float speed;
    public SpawnBullet spawner;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        speed = 4;
        _rb.linearVelocityY = speed;
        Destroy(gameObject, 3f);
        spawner.BulletsStack.Push(gameObject);
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
