using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inamic : MonoBehaviour
{
    float x = 0;
    int dir = 1;
    bool wait = false;
    public float offset = 3;
    public float viteza = 5;
    public float viteza_rotatie = 10;
    Animator x1;
    // Start is called before the first frame update
    void Start()
    {
        x = gameObject.transform.position.x;
        x1 = GetComponent<Animator>();

        gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dest = new Vector3(x + offset* dir,gameObject.transform.position.y, gameObject.transform.position.z);

        if ((gameObject.transform.position - dest).magnitude < 0.5)
        {
            dir = dir * -1;
            StartCoroutine(asteptare(2));

        }

        if(wait == false) gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, dest, 0.01f * viteza);

        Vector3 rotatie = gameObject.transform.eulerAngles;
        rotatie.y = Mathf.LerpAngle(rotatie.y, 90 * dir, 0.01f * viteza_rotatie);
        gameObject.transform.eulerAngles = rotatie;

        x1.SetInteger("move", Convert.ToInt32(!wait));

    }

    IEnumerator asteptare(float secunde) {
        wait = true;
        yield return new WaitForSeconds(secunde);
        wait = false;
    }
}
