using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private Vector3 offset;

    void Start()
    {
        offset = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Slerp(new Vector3(offset.x, offset.y + target.transform.position.y, offset.z), transform.position, lerpSpeed);
    }
}