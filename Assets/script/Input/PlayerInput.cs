using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName="Player Input")]
public class PlayerInput : ScriptableObject,InputActions.IGamePlayActions
{
    InputActions inputActions;

    public void OnMove(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {

            case InputActionPhase.Started://开始的那一刻
                break;
            case InputActionPhase.Performed://持续按下
                break;
            case InputActionPhase.Canceled://松开
                break;
        }
    }

    private void OnEnable()
    {
        inputActions=new InputActions();

        inputActions.GamePlay.SetCallbacks(this);
    }


}
