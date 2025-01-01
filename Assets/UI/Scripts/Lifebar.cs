using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    public Slider sli;

    public void setMaxLife(int life)
    {
        sli.maxValue = life;  //��Ѫ��������������ֵ��ʼ
        sli.value = life;     
    }

    public void setLifebar(int life)
    {
        sli.value = life;
    }
  
   
}
