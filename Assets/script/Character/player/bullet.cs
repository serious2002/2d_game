using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float lifetime;
    private float shoottime;
    // Start is called before the first frame update
    void Start()
    {
        shoottime=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > shoottime+lifetime)
        {
            Destroy(gameObject);
        }

    }


}