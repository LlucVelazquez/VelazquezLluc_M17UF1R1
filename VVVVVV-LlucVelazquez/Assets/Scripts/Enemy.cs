using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    public GameObject LimitL;
    public GameObject LimitR;
    private SpriteRenderer _sr;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        speed = 4;
        _rb.linearVelocityX = speed;
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.linearVelocityX = speed;
        /*AudioManager.Instance.PlaySource(AudioClips.Enemy);
        AudioManager.Instance.RepeatSource(true);*/
        if (LimitL.transform.position.x >= _rb.transform.position.x)
        {
            _sr.flipX = false;
            speed = 4;
        }
        else if(LimitR.transform.position.x <= _rb.transform.position.x)
        {
            _sr.flipX = true;
            speed = -4;
        }
    }
}
