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
            onMove?.Invoke(context.ReadValue<Vector2>());//�����¼������ݷ���
        }
        //switch (context.phase)
        //{

        //    case InputActionPhase.Started://��ʼ����һ��
        //        break;
        //    case InputActionPhase.Performed://��������
        //        break;
        //    case InputActionPhase.Canceled://�ɿ�
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
        inputActions.GamePlay.Enable();//����Gameplay������
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        
    }
}
