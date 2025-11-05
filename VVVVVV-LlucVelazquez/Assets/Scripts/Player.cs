using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MoveBehaviour))]
public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private MoveBehaviour _mb;
    private InputSystem_Actions inputActions;
    private int gravity = 1;

    private void Awake()
    {
        _mb = GetComponent<MoveBehaviour>();
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
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
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        direction.y = 0;
        _mb.MoveCharacter(direction);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        inputActions.Disable();
    }
}
