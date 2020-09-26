using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAppear : MonoBehaviour
{

    public Text credits;
    public float wait = 0.05f;

    string text;

    private void Awake()
    {
        text = credits.text;
        credits.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(appear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator appear()
    {
        while (text.Length > 0)
        {
            credits.text += text[0];
            text = text.Substring(1);
            yield return new WaitForSeconds(wait);
        }

        yield return new WaitForSeconds(4f);

        Application.LoadLevel("Menu");

    }
}
