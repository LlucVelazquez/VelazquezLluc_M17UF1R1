using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float speed;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        speed = -2;
        _rb.linearVelocity = new Vector2(0, speed);
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 10 || collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }
}
