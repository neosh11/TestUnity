using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    // Sensitivities for mouse inputs
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;


    // Limits on vertical + mouse vert angle
    private float _rotationX = 0;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // GetAxis is rate independent
        // Calc and clamp vertical rotation 
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        // Calc and pres horizontal rotaion
        float delta = Input.GetAxis("Mouse X") * sensitivityHor;
        float rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);


    }
}
