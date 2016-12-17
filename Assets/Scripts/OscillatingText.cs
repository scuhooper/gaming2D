using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This simple script handles the cute rotating text on the title screen
/// </summary>
public class OscillatingText : MonoBehaviour {

    public Vector3 from = new Vector3(0f, 0f, 0f);
    public Vector3 to = new Vector3(0f, 0f, 0f);
    public float speed = 1.0f;

    void Update()
    {
        float t = (Mathf.Sin(Time.time * speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f; //Handles a more organic approach to the rotating
       // float t = Mathf.PingPong(Time.time * speed * 2.0f, 1.0f); //Rotates, but a little more aggressive
        transform.eulerAngles = Vector3.Lerp(from, to, t);

    }
}
