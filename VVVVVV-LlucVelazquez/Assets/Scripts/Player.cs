using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MoveBehaviour))]
public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private MoveBehaviour _mb;
    private InputSystem_Actions inputActions;
    private int gravity = 1;
    float Xdirection = 0f;
    private Animator animator;

    private void Awake()
    {
        _mb = GetComponent<MoveBehaviour>();
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
        animator = GetComponent<Animator>();
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
    }
    private void Update()
    {
        _mb.MoveCharacter(new Vector2 (Xdirection, 0));

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Xdirection = context.ReadValue<Vector2>().x;
        if (Xdirection != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7 || collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        animator.SetBool("isDead", true);
        inputActions.Disable();
    }
}
