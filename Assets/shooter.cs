using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{

    // 1 - Designer variables

    /// <summary>
    /// Vitesse de déplacement
    /// </summary>
    public Vector2 speed = new Vector2(1, 1);

    /// <summary>
    /// Direction
    /// </summary>
    public Vector2 direction;

    private Vector2 movement;

    private bool shot = false;
    private bool collided = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            // convert mouse position into world coordinates
            Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Allow shoot only if the player doesn't shoot downwards
            if (mouseScreenPosition.y > transform.position.y && !shot) {
                // get direction you want to point at
                direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
                // Update movement vector
                movement = direction * speed;
                shot = true;
            }

            
        }
           
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.transform.parent.gameObject.name == "contourLeft" || col.gameObject.transform.parent.gameObject.name == "contourRight")
        {
            direction = new Vector2(-direction.x, direction.y);
            movement = direction * speed;
        } else if (collided) {
            movement = new Vector2(0, 0);
        } else {
            movement = direction / 3;
            collided =true;
        }
    }

    void FixedUpdate()
    {
        // Application du mouvement
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}