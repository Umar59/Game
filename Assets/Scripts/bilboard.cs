using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bilboard : MonoBehaviour
{
    
    public Camera camera;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void LateUpdate()
    {

        transform.LookAt(transform.position + camera.transform.forward);

    }
}
