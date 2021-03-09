using UnityEngine;

/// <summary>
/// Controls the behaviour of the player's gun.
/// </summary>
public class Gun : Weapon
{
    [Header("Firing")]
    public float CannonballSpeed = 500f;
    public Transform FirePoint;
    public GameObject MuzzleFlash;
    public GameObject CannonballPrefab;

    private PlayerMovementController playerMovementController;
    private Animator gunAnimator;
    private Animator muzzleFlashAnimator;

    /// <summary>
    /// Called by Unity when this GameObject starts.
    /// </summary>
    private void Start()
    {
        playerMovementController = GetComponentInParent<PlayerMovementController>();
        gunAnimator = GetComponent<Animator>();
        muzzleFlashAnimator = MuzzleFlash.GetComponent<Animator>();
    }

    /// <summary>
    /// Instantiates a projectile and sets it's velocity relative to the player's current direction.
    /// </summary>
    protected override void HandleAttack()
    {
        // Create a cannonball, set it's owner and velocity.
        var cannonball = Instantiate(CannonballPrefab, FirePoint.position, Quaternion.identity);
        cannonball.GetComponent<Cannonball>().Owner = playerMovementController.gameObject;
        cannonball.GetComponent<Rigidbody2D>().velocity = new Vector2(playerMovementController.GetDirection() * CannonballSpeed, 0);

        // Play the gun firing animations.
        gunAnimator.SetTrigger("Fire");
        muzzleFlashAnimator.SetTrigger("Fire");
    }
}
