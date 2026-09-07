using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator anim;
    public GameObject player;
    public GameObject distraction;
    public float detectionRadius = 10f;
    public float distracitonRadius = 5f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        float distractionDistance = Vector3.Distance(transform.position, distraction.transform.position);

        if (distance <= detectionRadius && distractionDistance > distracitonRadius)
        {
            anim.SetTrigger("Threatened");
        } else if (distractionDistance <= distracitonRadius)
        {
            anim.SetTrigger("Distracted");
        }
        else
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
