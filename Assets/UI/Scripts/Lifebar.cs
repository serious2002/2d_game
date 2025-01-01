using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    public Slider sli;

    public void setMaxLife(int life)
    {
        sli.maxValue = life;  //让血条滑块从最大生命值开始
        sli.value = life;     
    }

    public void setLifebar(int life)
    {
        sli.value = life;
    }
  
   
}
