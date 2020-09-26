using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Personaj : MonoBehaviour
{
    [Header("Fizici")]
    public float viteza = 10f;
    public float viteza_rot_directie = 5f;
    public float forta = 500;

    [Space]
    public GameObject leftLimit;
    public GameObject rightLimit;
    public float downLimit = -10;

    [Space]
    [Header("UI")]
    public Text scorTX;

    Rigidbody rb;
    Animator anim;

    int directie = 1;
    int scor = 0;
    bool isGrounded;

    [HideInInspector]
    public bool over = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        if(Application.loadedLevelName == "Level1")
        {
            PlayerPrefs.DeleteKey("score");
        }
        else
        {
            scor = PlayerPrefs.GetInt("score");
        }

        scorTX.text = "Scor: " + scor.ToString();

        gameObject.tag = "Player";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (over)
            return;

        float x = ControlFreak2.CF2Input.GetAxis("Horizontal");

        if (x > 0)
        {
            directie = 1;
        }
        else if (x < 0)
        {
            directie = -1;
        }

        Vector3 rotatie_pers = transform.eulerAngles;
        rotatie_pers.y = Mathf.LerpAngle(rotatie_pers.y, directie * 90, 0.01f * viteza_rot_directie);
        transform.eulerAngles = rotatie_pers;

        anim.SetFloat("Move", Mathf.Abs(x));
        anim.SetBool("Grounded", isGrounded);

        if (x > 0 && transform.position.x > rightLimit.transform.position.x)
            return;

        if (x < 0 && transform.position.x < leftLimit.transform.position.x)
            return;

        Vector3 pos = new Vector3();
        pos = transform.position;
        pos.x += x * viteza * Time.deltaTime;
        transform.position = pos;
      
        if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector3 forta_vect = new Vector3();
            forta_vect.y = forta;
            rb.velocity = Vector3.zero;
            rb.AddForce(forta_vect);

            anim.SetTrigger("Jump");
        }

        if (transform.position.y < downLimit)
        {
            GameManager.manager.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            GameManager.manager.GameOver();
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Plane")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Plane")
        {
            isGrounded = false;
        }
    }

    public void adauga_scor() {

        scor++;
        scorTX.text = "Scor: " + scor.ToString();
    }

    public void salveaza_scor()
    {
        PlayerPrefs.SetInt("score", scor);
    }

}
