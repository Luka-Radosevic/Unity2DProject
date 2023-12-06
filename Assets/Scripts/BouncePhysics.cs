using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePhysics : MonoBehaviour
{
    BoxCollider2D bc2D;
    private void Awake()
    {
        bc2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            float relativePosition = (other.transform.position.x - transform.position.x) / bc2D.bounds.size.x;
            other.rigidbody.velocity = new Vector2(relativePosition, 1).normalized * other.rigidbody.velocity.magnitude;
        }
    }
}
