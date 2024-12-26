using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="Player Input")]
public class PlayerInput : ScriptableObject
{
    InputActions inputActions;

    private void OnEnable()
    {
        inputActions=new InputActions();
    }


}
