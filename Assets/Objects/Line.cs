using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Line : MonoBehaviour
{
    public GameObject[] bubbles;
    public int nbBubbles = 17;

    // Use this for initialization
    void Start()
    {

        float x = 0f;
        float y = 0f;
        float z = 0f;

        for (int i = 0; i < nbBubbles; i++)
        {
            Vector3 position = new Vector3(x, y, z);
            GameObject bubble = Instantiate(bubbles[Random.Range(0, 5)], gameObject.transform);
            //bubble.transform.position = position;
            //bubble.transform.parent = gameObject.transform;
            
            x -= 0.63f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
