using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    public SpawnBullet spawner;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        speed = -3;
        _rb.linearVelocity = new Vector2(0, speed);
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 10 || collision.gameObject.layer == 6)
        {
            gameObject.SetActive(false);
            spawner.Push(gameObject);
        }
    }
}
