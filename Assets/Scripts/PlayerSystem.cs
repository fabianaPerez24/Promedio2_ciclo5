using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public enum PlayerMode
{
    Walker,
    Vehicle
}
public class PlayerSystem : Entity, IShoot
{

    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Disparo")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 0.2f;

    [Header("Transformación")]
    [SerializeField] private PlayerMode currentMode;
    [SerializeField] private GameObject walkerModel;
    [SerializeField] private GameObject vehicleModel;

    private Rigidbody rb;
    private Vector3 movement;
    private float nextFireTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MoveInput();
        RotateToMouse();
        ShootInput();

        if (Input.GetKeyDown(KeyCode.T))
        {
            TransformMode();
        }
    }
    private void TransformMode()
    {
        if (currentMode == PlayerMode.Walker)
        {
            currentMode = PlayerMode.Vehicle;

            walkerModel.SetActive(false);
            vehicleModel.SetActive(true);

            moveSpeed = 10f;
        }
        else
        {
            currentMode = PlayerMode.Walker;

            walkerModel.SetActive(true);
            vehicleModel.SetActive(false);

            moveSpeed = 5f;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyFortress"))
        {
            GetComponent<ChangeScenes>();
            SceneManager.LoadScene("Victoria");
        }
    }

    private void MoveInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(horizontal, 0, vertical).normalized;
    }

    private void MovePlayer()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void RotateToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);

            Vector3 direction = (point - transform.position).normalized;

            direction.y = 0;

            if (direction != Vector3.zero)
            {
                transform.forward = direction;
            }
        }
    }

    private void ShootInput()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();

            nextFireTime = Time.time + fireRate;
        }
    
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    protected override void Die()
    {
        Debug.Log("Jugador muerto");

        gameObject.SetActive(false);
    }
}
