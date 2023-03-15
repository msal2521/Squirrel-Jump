using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D _playerRigidBody;
    Animator anim;
    public Text tapText, tapText2;
    public GameObject TapButton;
    public static bool isMagnet;
    // starting value for the Lerp
    float t = 0.0f;
    // animate the game object from -1 to +1 and back
    public float minimum = 1.0F, maximum = 4.0F, thrust;

    //public CinemachineVirtualCamera playerCam, BGCam;
    bool cameraSwitch;
    public float speed = 0.5f;

    void Start()
    {
        isMagnet = false;
        player = GameObject.Find("Player");
        _playerRigidBody = player.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _playerRigidBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMassControl();
       // Debug.LogError("_playerRigidBody.velocity: " + _playerRigidBody.velocity);
    }

    private void PlayerMassControl()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            t += speed * Time.deltaTime;
            _playerRigidBody.isKinematic = false;
            _playerRigidBody.mass = Mathf.Lerp(minimum, maximum * 2f, t);
            _playerRigidBody.gravityScale = Mathf.Lerp(minimum, maximum, t);
            anim.SetBool("pressed", true);
        }
        else
        {
            _playerRigidBody.mass = 1;
            _playerRigidBody.gravityScale = 1;
            anim.SetBool("pressed", false);
            //t -= speed * Time.deltaTime;
            t = 0.0f;
        }
    }

    public void Ftue()
    {
        Time.timeScale = 1;
        tapText2.gameObject.SetActive(false);
        TapButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "trigger")
        {
            tapText.gameObject.SetActive(false);
            Time.timeScale = 0;
            tapText2.gameObject.SetActive(true);
        }

        if (collision.gameObject.tag == "magnet")
        {
            isMagnet = true;
            Destroy(collision.gameObject);
        }

    }

    public void FlyPowerUp()
    {
        Debug.Log("gfxgfxgfxgf");
        if (transform.rotation.y == 0)
        {
            _playerRigidBody.velocity = new Vector2(0.25f, 1) * thrust;
        }
        else
        {
            _playerRigidBody.velocity = new Vector2(-0.25f, 1) * thrust;
        }
    }

    //public void SwitchCamera()
    //{
    //    BGCam.Priority = 3;

    //}


    //public void SwitchCameraBack()
    //{
    //    BGCam.Priority = 1;

    //}
}
