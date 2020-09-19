using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banut : MonoBehaviour
{
    public float viteza_rot = 10f;
    public GameObject explosion;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, viteza_rot * Time.deltaTime, 0, Space.World);
    }

    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collision.collider.gameObject.tag);
        if (collider.gameObject.tag == "Player")
        {

            Instantiate(explosion, transform.position, transform.rotation);

            Personaj sferacontrol = collider.gameObject.GetComponent<Personaj>();

            sferacontrol.adauga_scor();
            Destroy(gameObject);

        }
    }
}
