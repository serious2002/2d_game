using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;


[CreateAssetMenu(fileName="Player Input")]
public class PlayerInput : ScriptableObject,InputActions.IGamePlayActions
{
    public event UnityAction<Vector2> onMove;

    InputActions inputActions;


    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onMove?.Invoke(context.ReadValue<Vector2>());//触发事件并传递方向
        }
        //switch (context.phase)
        //{

        //    case InputActionPhase.Started://开始的那一刻
        //        break;
        //    case InputActionPhase.Performed://持续按下
        //        break;
        //    case InputActionPhase.Canceled://松开
        //        break;
        //}
    }

    private void OnEnable()
    {
        inputActions=new InputActions();

        inputActions.GamePlay.SetCallbacks(this);
    }

    public void EnableGameplayeInput()
    {
        inputActions.GamePlay.Enable();//启用Gameplay动作表
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        
    }
}
