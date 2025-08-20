using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    [SerializeField] private float wanderRadius = 30f;

    private float minWaitTime = 1f;
    private float maxWaitTime = 5f;

    [SerializeField] private float turnSpeed = 10f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.updateRotation = false;
    }

    IEnumerator Start()
    {
        while (true)
        {
            SetRandomDestination();
            float moveType = Random.Range(0, 2) == 0 ? 0.5f : 1f;
            anim.SetFloat("Speed", moveType); // 이동 애니메이션
            agent.speed = moveType * 4f; // 2 or 4

            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

            //정지애니메이션
            anim.SetFloat("Speed", 0f);

            float idleTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(idleTime);
        }
    }

    private void Update()
    {
        // 속도 = 방향 설정
        Vector3 dir = agent.desiredVelocity;
        if(dir != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed);
        }
    }

    private void SetRandomDestination()
    {
        var randomDir = Random.insideUnitSphere * wanderRadius;
        randomDir += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDir, out hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
