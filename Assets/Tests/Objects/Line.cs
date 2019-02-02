using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Line : MonoBehaviour
{
    public GameObject[] bubbles;
    public int nbBubbles = 14;

    // Use this for initialization
    void Start()
    {

        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        float z = gameObject.transform.position.z;

        for (int i = 0; i < nbBubbles; i++)
        {
            GameObject bubble = Instantiate(bubbles[Random.Range(0, 5)]);
            bubble.transform.SetParent(gameObject.transform, false);
            Vector3 position = new Vector3(x, y, z);
            bubble.transform.position = position;
            x -= 0.63f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
