using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{

    // 1 - Designer variables

    /// <summary>
    /// Vitesse de déplacement
    /// </summary>
    private Vector2 speed = new Vector2(10, 10);

    /// <summary>
    /// Direction
    /// </summary>
    private Vector2 direction;

    private Vector2 movement;

    private bool shot = false;

    private GameObject g;

    private GameObject party;

    private GameObject mainBubble;

    private GameObject nextBubble;

    private List<GameObject> shots;

    private float width;

    private void Start()
    {
        shots = new List<GameObject>();
        party = gameObject.transform.parent.gameObject;
        mainBubble = Instantiate(party.GetComponent<Party>().bubbles[Random.Range(0, 5)], new Vector3(0, 0, 0), Quaternion.identity);
        mainBubble.transform.SetParent(gameObject.transform, false);
        mainBubble.AddComponent<Rigidbody2D>().gravityScale = 0;
        mainBubble.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        mainBubble.AddComponent<Bubble>();
        mainBubble.AddComponent<RectTransform>();
        nextBubble = Instantiate(party.GetComponent<Party>().bubbles[Random.Range(0, 5)], new Vector3(7, 0, 0), Quaternion.identity);
        nextBubble.transform.SetParent(gameObject.transform, false);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shot = true;
        }
    }

    void FixedUpdate()
    {
        if (mainBubble.GetComponent<Bubble>() != null)
        {
            if (mainBubble.GetComponent<Bubble>().movement == new Vector2(0, 0) && shot)
            {
                //GameObject.Destroy(mainBubble.GetComponent<Rigidbody2D>());
                GameObject.Destroy(mainBubble.GetComponent<Bubble>());
                mainBubble.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                mainBubble = Instantiate(nextBubble, new Vector3(0, 0, 0), Quaternion.identity);
                //mainBubble.transform.SetParent(gameObject.transform, false);
                //mainBubble = nextBubble;
                mainBubble.AddComponent<Rigidbody2D>().gravityScale = 0;
                mainBubble.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                mainBubble.AddComponent<Bubble>();
                mainBubble.AddComponent<RectTransform>();
                mainBubble.transform.position = new Vector3(0, 0, 0);
                mainBubble.transform.SetParent(gameObject.transform, false);
                GameObject.Destroy(nextBubble);
                nextBubble = Instantiate(party.GetComponent<Party>().bubbles[Random.Range(0, 5)], new Vector3(7, 0, 0), Quaternion.identity);
                nextBubble.transform.SetParent(gameObject.transform, false);
                shot = false;
            }
        }
    }
}