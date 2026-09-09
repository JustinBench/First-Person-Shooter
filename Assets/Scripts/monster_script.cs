using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Monster : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject distraction;
    public GameObject weakness;
    public float detectionRadius = 0f;
    public float distractionRadius = 0f;
    public bool deathByWeakness = false;
    public float weaknessRadius = 1.0f;
    private Animator anim;
    private Health health;

    void Start()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        health.OnDie += Death;
        health.Invincible = true;
    }

    void Death()
    {
        anim.SetTrigger("Dies");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        float distractionDistance = distractionRadius * 2;

        if (distraction != null)
        {
            distractionDistance = Vector3.Distance(transform.position, distraction.transform.position);
        }

        if (weakness != null && deathByWeakness)
        {
            float weaknessDistance = Vector3.Distance(transform.position, weakness.transform.position);
            if (weaknessDistance <= weaknessRadius)
            {
                anim.SetTrigger("Weakened");
                health.Invincible = false;
                health.TakeDamage(1, weakness);
                health.Invincible = true;
            }
        }

        if (distance <= detectionRadius && ((distraction != null && distractionDistance > distractionRadius) || distraction == null))
        {
            anim.SetTrigger("Threatened");
            if (deathByWeakness == false)
            {
                health.Invincible = false;
            }
        }
        else if (distraction != null && distractionDistance <= distractionRadius)
        {
            anim.SetTrigger("Distracted");
        }
        else
        {
            anim.SetTrigger("Idle");
            health.Invincible = true;
        }
    }
}
