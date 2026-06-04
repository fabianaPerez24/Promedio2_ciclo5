using UnityEngine;

public class Superplane : Entity
{
    private enum State
    {
        Patrol,
        Attack
    }

    private State currentState;

    [SerializeField] private Transform baseToProtect;

    [SerializeField] private float patrolRadius = 5f;
    [SerializeField] private float detectionRadius = 10f;

    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f;

    private float nextFireTime;

    private Vector3 patrolPoint;
    private void Start()
    {
        PatrolArea();
    }
    private void PatrolArea()
    {
        patrolPoint = baseToProtect.position +
            new Vector3(
                Random.Range(-patrolRadius, patrolRadius), 0,
                Random.Range(-patrolRadius, patrolRadius));
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRadius)
            currentState = State.Attack;
        else
            currentState = State.Patrol;

        if (currentState == State.Patrol)
        {
            PatrolMovement();
        }
        else if (currentState == State.Attack)
        {
            AttackPlayer();
        }
    }
    private void PatrolMovement()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            patrolPoint,
            speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, patrolPoint) < 1f)
        {
            PatrolArea();
        }
    }
    private void AttackPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            transform.forward = direction.normalized;
        }

        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation);
    }
    protected override void Die()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, patrolRadius);
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
