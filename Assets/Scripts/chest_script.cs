using UnityEngine;
using UnityEngine.UIElements;

public class Chest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 0.0f;
    public float turnSpeed = 0.0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
