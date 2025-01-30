using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionNavMesh : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] GameObject player;
    [SerializeField] float evasionDistance = 2f;
    [SerializeField] float evasionUpdateInterval = 0.5f;
    private Vector3 evasionOffset = Vector3.zero;
    private float timeSinceLasetEvasionUpdate = 0f;
    [SerializeField] float blineDistance = 3f;
    [SerializeField] bool isStopped;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            agent.isStopped = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            agent.isStopped = false;
        }
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if (player == null || agent == null) return;

        timeSinceLasetEvasionUpdate += Time.deltaTime;
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (timeSinceLasetEvasionUpdate >= evasionUpdateInterval && agent.isStopped == false)
        {
            UpdateEvasionOffset();
            timeSinceLasetEvasionUpdate = 0f;
        }
        if (distanceToPlayer <= blineDistance && agent.isStopped == false)
        {
            if (agent.destination != player.transform.position)
            {
                agent.SetDestination(player.transform.position);
            }
        }
        else
        {
            if (agent.isStopped == false)
            {
                Vector3 directionToPlayer = player.transform.position - transform.position;
                directionToPlayer.y = 0f;
                Vector3 evadeDestination = player.transform.position + evasionOffset;
                agent.destination = evadeDestination;
            }
        }
        FacePlayer();
    }

    private void FacePlayer()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            directionToPlayer.y = 0f; // Ignore vertical rotation to prevent tilting

            if (directionToPlayer != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // Smooth rotation
            }
        }
    }

    private void UpdateEvasionOffset()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.y = 0;
        Vector3 perpendicular = Vector3.Cross(directionToPlayer, Vector3.up).normalized;
        float randomDirection = Random.value > 0.5f ? 1f : -1f;

        float verticalOffset = Random.Range(-evasionDistance * 0.5f, evasionDistance * 0.5f);

        evasionOffset = (perpendicular * randomDirection * evasionDistance) + (Vector3.up * verticalOffset);
    }
    public void TakeDamage(int damageAmount)
    {
        Debug.Log($"{damageAmount} damage taken");
    }
}
