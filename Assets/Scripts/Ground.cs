using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject playerPos;
    Vector3 initialPos;
    //public Objective _objective;

    private void Start()
    {
        initialPos = playerPos.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Objective.isObjectiveComplete)
        {
            Time.timeScale = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !Objective.isObjectiveComplete)
        {
            collision.gameObject.transform.position = initialPos;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
