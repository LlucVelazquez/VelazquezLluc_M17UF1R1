using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speedX;
    public float speedY;
    public SpawnBullet spawner;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocity = new Vector2(speedX, speedY);
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
