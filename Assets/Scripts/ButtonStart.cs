using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : MonoBehaviour
{
    float value;

    Vector3 startScale;

    private void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        value += Time.deltaTime * 5f;

        var x = Mathf.Sin(value) * 0.1f;

        var y = Mathf.Cos(value) * 0.05f;

        transform.localScale = new Vector3(startScale.x + x, startScale.y + x, 1f);
    }
}
