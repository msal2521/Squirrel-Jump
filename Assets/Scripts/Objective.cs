using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    //public GameObject playerPos;
    public GameObject winPanel, magText;
    public static bool isObjectiveComplete;
    //Vector3 initialPos; 
    private Transform Player;

    public Vector3 pos;
    public float height, speed;

    private void Start()
    {
        pos = transform.position;
        isObjectiveComplete = false;
        Player = GameObject.Find("Player").GetComponent<Transform>();
        //initialPos = playerPos.transform.position;
    }

    private void Update()
    {
        if (PlayerController.isMagnet)
        {
            if(Vector3.Distance(transform.position, Player.position) < 5)
                transform.position = Vector3.MoveTowards(transform.position, Player.position, 0.1f);
        }

        if (SceneManager.GetActiveScene().buildIndex == 11/* || SceneManager.GetActiveScene().buildIndex == 4*/)
            VerticalMotion();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //gameObject.SetActive(false);
            if (SceneManager.GetActiveScene().buildIndex == 11 || SceneManager.GetActiveScene().buildIndex == 12)
            {
                magText.SetActive(false);
            }
            winPanel.SetActive(true);
            Debug.Log("Round Win");
            isObjectiveComplete = true;
            this.gameObject.SetActive(false);
            //transform.SetParent(collision.transform);
        }
    }

    public void VerticalMotion()
    {
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y / 2f;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player" && !isObjectiveComplete)
    //    {
    //        collision.gameObject.transform.position = initialPos;
    //        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
    //    }
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        collision.gameObject.transform.position = initialPos;
    //    }
    //}
}
