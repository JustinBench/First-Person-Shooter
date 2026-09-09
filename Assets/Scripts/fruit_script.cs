using UnityEngine;

public class banana_script : MonoBehaviour
{
    public float pushDistance = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 pushDirection = transform.position - other.transform.position;
            pushDirection.y = 0f;
            pushDirection.Normalize();

            transform.position += pushDirection * pushDistance;
        }
    }
}
