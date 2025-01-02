using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success3 : MonoBehaviour
{
    public GameObject goal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyManager.Instance.enemyCount == 0 && EnemyManager.Instance.currentWaveIndex >=2)
        {
            goal.SetActive(true);
        }
    }
}
