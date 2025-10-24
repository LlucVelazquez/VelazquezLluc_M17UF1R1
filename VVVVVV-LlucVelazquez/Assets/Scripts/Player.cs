using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(MoveBehaviour))]
public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private MoveBehaviour _mb;
    private InputSystem_Actions inputActions;
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
        //_mb.ChangeGravity()
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _mb.MoveCharacter(context.ReadValue<Vector2>());
    }
}
