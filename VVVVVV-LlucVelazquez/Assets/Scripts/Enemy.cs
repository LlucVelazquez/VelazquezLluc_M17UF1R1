using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    public GameObject LimitL;
    public GameObject LimitR;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        speed = 4;
        _rb.linearVelocityX = speed;
    }

    // Update is called once per frame
    void Update()
    {
        _rb.linearVelocityX = speed;
        if (LimitL.transform.position.x >= _rb.transform.position.x)
        {
            speed = 4;
        }
        else if(LimitR.transform.position.x <= _rb.transform.position.x)
        {
            speed = -4;
        }
    }
}
