using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bilboard : MonoBehaviour
{
    public GameObject camera;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void LateUpdate()
    {

        transform.LookAt(transform.position + camera.transform.forward);

    }
}
