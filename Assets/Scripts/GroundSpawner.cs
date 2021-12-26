using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public Transform straight;
    public Transform left;
    public Transform right;
    public Transform crossbar;
    public Transform coin;

    List<Transform> groundList;

    Vector3 rotation;

    int n;

    void Start()
    {
        groundList = new List<Transform>();
        rotation = Vector3.zero;
        n = 0;

        for(int i = 0; i < 30; i++)
        {
            Transform t = null;
            if (i == 0)
            {
                t = Instantiate(straight);
                t.parent = transform;
                t.localPosition = new Vector3(0f, 0f, 8f);
                groundList.Add(t);
            }
            else
            {
                Transform prev = groundList[i - 1];

                if (prev.name == "module_02_tile_02_ac Variant(Clone)")
                {
                    if (Random.Range(0, 2) == 1)
                    {
                        t = Instantiate(left);
                    }
                    else
                    {
                        t = Instantiate(right);
                    }
                    t.parent = transform;
                    t.Rotate(prev.eulerAngles);
                    t.position = prev.position;
                    t.position += prev.rotation * new Vector3(0f, 0f, 8f);
                    groundList.Add(t);
                }
                else if (prev.name == "module_02_corner_convex_b Variant(Clone)")
                {
                    t = Instantiate(straight);
                    t.parent = transform;
                    t.Rotate(prev.eulerAngles);
                    t.Rotate(0f, -90f, 0f);
                    t.position = prev.position;
                    t.position += prev.rotation * new Vector3(-8f, 0f, 0f);
                    groundList.Add(t);
                    for (int j = Random.Range(3, 6); j >= 0; j--, i++)
                    {
                        prev = t;
                        t = Instantiate(straight);
                        t.parent = transform;
                        t.Rotate(prev.eulerAngles);
                        t.position = prev.position;
                        t.position += prev.rotation * new Vector3(0f, 0f, 8f);
                        if (Random.Range(0, 6) == 0)
                        {
                            Transform b = Instantiate(crossbar);
                            b.parent = t;
                            b.Rotate(t.eulerAngles);
                            b.localPosition = new Vector3(0f, 1f, 0f);

                            Transform c = Instantiate(coin);
                            c.parent = t;
                            c.Rotate(t.eulerAngles);
                            c.localPosition = new Vector3(0f, 3.5f, 0f);
                        }
                        else if (Random.Range (0, 3) == 0)
                        {
                            Transform c = Instantiate(coin);
                            c.parent = t;
                            c.Rotate(t.eulerAngles);
                            c.localPosition = new Vector3(0f, 3.5f, 0f);
                        }
                        groundList.Add(t);
                    }
                }
                else if (prev.name == "module_02_corner_convex_a Variant(Clone)")
                {
                    t = Instantiate(straight);
                    t.parent = transform;
                    t.Rotate(prev.eulerAngles);
                    t.Rotate(0f, 90f, 0f);
                    t.position = prev.position;
                    t.position += prev.rotation * new Vector3(8f, 0f, 0f);
                    groundList.Add(t);

                    for (int j = Random.Range(3, 6); j >= 0; j--, i++)
                    {
                        prev = t;
                        t = Instantiate(straight);
                        t.parent = transform;
                        t.Rotate(prev.eulerAngles);
                        t.position = prev.position;
                        t.position += prev.rotation * new Vector3(0f, 0f, 8f);
                        if (Random.Range(0, 6) == 0)
                        {
                            Transform b = Instantiate(crossbar);
                            b.parent = t;
                            b.Rotate(t.eulerAngles);
                            b.localPosition = new Vector3(0f, 1f, 0f);

                            Transform c = Instantiate(coin);
                            c.parent = t;
                            c.Rotate(t.eulerAngles);
                            c.localPosition = new Vector3(0f, 3.5f, 0f);
                        }
                        else if (Random.Range(0, 3) == 0)
                        {
                            Transform c = Instantiate(coin);
                            c.parent = t;
                            c.Rotate(t.eulerAngles);
                            c.localPosition = new Vector3(0f, 3.5f, 0f);
                        }
                        groundList.Add(t);
                    }
                }
                else
                {
                    Debug.Log("Ground List transform name error.");
                    Debug.Log(prev.transform.name);
                }

            }
        }

    }

    void Update()
    {
        for(int i = 0; i < groundList.Count; i++)
        {
            if (GameObject.Find(groundList[i].name) == null)
            {
                Transform prev;
                if (i == 0)
                    prev = groundList[groundList.Count - 1];
                else
                    prev = groundList[i - 1];

                switch (Random.Range(0, 3))
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
