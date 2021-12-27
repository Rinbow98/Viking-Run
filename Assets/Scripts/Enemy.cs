using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Enemy : MonoBehaviour
{
    List<Vector3> positions;
    Transform player;

    public int num;
    int index;

    void Start()
    {
        positions = new List<Vector3>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        index = 0;
    }

    void Update()
    {
        bool start = HowToPlay.GameStart;
        if(start && num > 0)
        {
            positions.Add(player.position);
            num--;
        }
        else if (start)
        {
            transform.position = new Vector3(positions[index].x, 2f, positions[index].z);
            positions[index] = player.position;

            transform.rotation = player.rotation;
            transform.Rotate(-90f, 0f, 0f);

            if (index == positions.Count - 1)
                index = 0;
            else
                index++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
