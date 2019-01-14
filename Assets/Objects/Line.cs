using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Line : MonoBehaviour
{
    List<Bubble> bubbles = new List<Bubble>();
    int size = 15;
    float width;
    float height;

    // Use this for initialization
    void Start()
    {
        float x = 0;
        float y = 0;
        float z = 0;

        for (int i = 0; i < size; i++)
        {
            x -= 063;
            Bubble bubble = new Bubble();
            bubble.transform.position = new Vector3(x, y, z);
            bubbles.Add(bubble);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
