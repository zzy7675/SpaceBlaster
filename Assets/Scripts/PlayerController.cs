using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;
    [SerializeField] float topBoundPadding;
    [SerializeField] float botBoundPadding;
    Shooter playerShooter;
    InputAction moveAction;
    InputAction fireAction;
    Vector3 moveVector;
    Vector2 minBound;
    Vector2 maxBound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerShooter = GetComponent<Shooter>();
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Fire");
        InitBound();
    }

    void InitBound()
    {
        Camera camera = Camera.main;
        minBound = camera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = camera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        FireShooter();
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector2 newPosition = transform.position + moveVector * moveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minBound.x + leftBoundPadding, maxBound.x - rightBoundPadding);
        newPosition.y = Mathf.Clamp(newPosition.y, minBound.y + botBoundPadding, maxBound.y - topBoundPadding);
        transform.position = newPosition;
    }

    void FireShooter()
    {
        playerShooter.isFiring = fireAction.IsPressed();
    }
}
