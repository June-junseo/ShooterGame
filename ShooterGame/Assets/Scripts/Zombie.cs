using UnityEngine;
using UnityEngine.AI;

public class Zombie : LivingEntity
{
    public LayerMask targetLayer;

    private LivingEntity targetEntity;
    private NavMeshAgent agent;

    public ParticleSystem hitEffect;

    private Animator zombieAnimator;

    private Renderer zombieRenderer;

    public float damage = 30f;

    public float timeBetAttack = 0.5f;

    private float lastTimeAttack;

    private void Start()
    {
        zombieAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        zombieRenderer = GetComponent<Renderer>();
    }


}

