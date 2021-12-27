using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestory : MonoBehaviour
{
    Transform player;
    Transform camera;
    public bool IsDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        IsDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = camera.position + (camera.position - player.position) * 4 / 3;

        if (Mathf.Abs(transform.position.x - position.x) < 1f && Mathf.Abs(transform.position.z - position.z) < 1f)
        {
            Destroy(gameObject);
            IsDestroyed = true;
        }
    }
}
