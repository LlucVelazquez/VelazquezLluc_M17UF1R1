using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
[RequireComponent(typeof(MoveBehaviour))]
public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private MoveBehaviour _mb;
    private InputSystem_Actions inputActions;
    private int gravity = 1;
    float Xdirection = 0f;
    private Animator animator;
    private SpriteRenderer _sr;
    private float posX;
    public GameObject gameWinMenu;
    public static event Action death = delegate { };
    private void Awake()
    {
        _mb = GetComponent<MoveBehaviour>();
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
        animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        gravity = gravity * -1;
        _mb.ChangeGravity(gravity);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1);
        if (context.performed)
        {
            AudioManager.Instance.PlaySource(AudioClips.Fly);
        }
    }
    private void Update()
    {
        _mb.MoveCharacter(new Vector2 (Xdirection, 0));

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Xdirection = context.ReadValue<Vector2>().x;
        if (context.performed)
        {
            AudioManager.Instance.PlaySource(AudioClips.Walk);
            AudioManager.Instance.RepeatSource(true);
        }
        if (Xdirection != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if (Xdirection > 0)
        {
            _sr.flipX = false;
        }
        else
        {
            _sr.flipX = true;
        }
        if (context.canceled)
        {
            AudioManager.Instance.RepeatSource(false);
            AudioManager.Instance.StopSource();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7 || collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            animator.SetBool("isDead", true);
            death.Invoke();
            inputActions.Disable();
        }
        if(collision.gameObject.layer == 11)
        {
            posX = transform.position.x;
            transform.position = new Vector3 (posX, -7.83f, -0.1f);   
        }
        if (collision.gameObject.layer == 12)
        {
            GameWin();
        }
    }
    
    public void GameWin()
    {
        inputActions.Disable();
        gameWinMenu.SetActive(true);
    }
}
