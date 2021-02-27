using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/Movement Input")]
public class KeyboardInput : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 6.0f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float deltaY = Input.GetAxis("UpDown") * speed * Time.deltaTime;
        transform.Translate(deltaX , deltaY, deltaZ);
    }
}
