using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobUpDown : MonoBehaviour
{
    [SerializeField] private float speed, start, end;

    void Update()
    {
        float s = Mathf.SmoothStep(start, end, Mathf.PingPong(Time.time * speed, 1));
        transform.localPosition = new Vector3(transform.localPosition.x, s, transform.localScale.z);
    }
}
