using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public float speed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float timeCorrectedSpeed = Time.deltaTime * speed * 100;
        transform.Rotate(0, timeCorrectedSpeed, 0);
    }
}
