using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapFollow : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 trans = player.position;
        trans.y = transform.position.y;
        transform.position = trans;
      //  transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);

    }
}
