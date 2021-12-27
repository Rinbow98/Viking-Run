using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Transform player;

    Vector3 offset;

    [SerializeField] float smoothing;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
    }

    void Update()
    {
        Vector3 targetPosition = player.position + player.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothing);
        transform.LookAt(player.position + new Vector3(0, 2, 0));
    }
}
