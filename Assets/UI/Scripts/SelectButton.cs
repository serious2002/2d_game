using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour
{
    public void SelectMenu()
    {
        SceneManager.LoadScene(7);
    }
}
