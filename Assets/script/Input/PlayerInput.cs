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

            case InputActionPhase.Started://��ʼ����һ��
                break;
            case InputActionPhase.Performed://��������
                break;
            case InputActionPhase.Canceled://�ɿ�
                break;
        }
    }

    private void OnEnable()
    {
        inputActions=new InputActions();

        inputActions.GamePlay.SetCallbacks(this);
    }


}
