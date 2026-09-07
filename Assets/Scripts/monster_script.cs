using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Monster : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject distraction;
    public float detectionRadius = 0f;
    public float distractionRadius = 0f;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        float distractionDistance = Vector3.Distance(transform.position, distraction.transform.position);

        if (distance <= detectionRadius && distractionDistance > distractionRadius)
        {
            anim.SetTrigger("Threatened");
        } else if (distractionDistance <= distractionRadius)
        {
            anim.SetTrigger("Distracted");
        } else
        {
            anim.SetTrigger("Idle");
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("Threatened");
        }
    }*/
}
