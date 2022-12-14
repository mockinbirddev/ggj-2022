#pragma warning disable 0108
using System;
using Fusion;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class MockingBirdNetworkCharacterControllerPrototype : NetworkTransform {
  // [Header("Character Controller Settings")]
  // public float gravity       = 0f;
  // public float jumpImpulse   = 8.0f;
  // public float acceleration  = 10.0f;
  // public float braking       = 10.0f;
  // public float maxSpeed      = 5.0f;
  // public float rotationSpeed = 0f;
  public float speed = 1f;

  //For some reason, the prototype code used a charactercontroller which is not 
  //compatible with 2D collision/interactions
  public Rigidbody2D rigidbody2D;
  private void Start() 
  {
    if(rigidbody2D == null) rigidbody2D = this.GetComponent<Rigidbody2D>();  
  }

  // [Networked]
  // [HideInInspector]
  // public bool IsGrounded { get; set; }

  [Networked]
  [HideInInspector]
  public Vector2 Velocity { get; set; }

  /// <summary>
  /// Sets the default teleport interpolation velocity to be the CC's current velocity.
  /// For more details on how this field is used, see <see cref="NetworkTransform.TeleportToPosition"/>.
  /// </summary>
  // protected override Vector3 DefaultTeleportInterpolationVelocity => Velocity;

  /// <summary>
  /// Sets the default teleport interpolation angular velocity to be the CC's rotation speed on the Z axis.
  /// For more details on how this field is used, see <see cref="NetworkTransform.TeleportToRotation"/>.
  /// </summary>
  // protected override Vector3 DefaultTeleportInterpolationAngularVelocity => new Vector3(0f, 0f, rotationSpeed);


  protected override void Awake() {
    base.Awake();
    // CacheController();
  }

  public override void Spawned() {
    base.Spawned();
    // CacheController();
  }

  // private void CacheController() {
  //   if (Controller == null) {
  //     Controller = GetComponent<CharacterController>();

  //     Assert.Check(Controller != null, $"An object with {nameof(NetworkCharacterControllerPrototype)} must also have a {nameof(CharacterController)} component.");
  //   }
  // }

  protected override void CopyFromBufferToEngine() {
    // Trick: CC must be disabled before resetting the transform state
    // Controller.enabled = false;

    // Pull base (NetworkTransform) state from networked data buffer
    base.CopyFromBufferToEngine();

    // Re-enable CC
    // Controller.enabled = true;
  }

  /// <summary>
  /// Basic implementation of a jump impulse (immediately integrates a vertical component to Velocity).
  /// <param name="ignoreGrounded">Jump even if not in a grounded state.</param>
  /// <param name="overrideImpulse">Optional field to override the jump impulse. If null, <see cref="jumpImpulse"/> is used.</param>
  /// </summary>
  // public virtual void Jump(bool ignoreGrounded = false, float? overrideImpulse = null) {
  //   // if (IsGrounded || ignoreGrounded) {
  //   //   var newVel = Velocity;
  //   //   newVel.y += overrideImpulse ?? jumpImpulse;
  //   //   Velocity =  newVel;
  //   // }
  // }

  /// <summary>
  /// Basic implementation of a character controller's movement function based on an intended direction.
  /// <param name="direction">Intended movement direction, subject to movement query, acceleration and max speed values.</param>
  /// </summary>
  public virtual void Move(Vector2 direction) {
    var deltaTime    = Runner.DeltaTime;
    var previousPos  = transform.position;
    Vector2 moveVelocity = Velocity;

    direction = direction.normalized;

    // We 2D topdown, don't need
    // if (IsGrounded && moveVelocity.y < 0) {
    //   moveVelocity.y = 0f;
    // }

    // Taking Out Effects of gravity
    // moveVelocity.y += gravity * Runner.DeltaTime;

    // var horizontalVel = default(Vector2);
    // horizontalVel.x = moveVelocity.x;
    // horizontalVel.z = moveVelocity.z;

    // if (direction == default) {
    //   horizontalVel = Vector3.Lerp(horizontalVel, default, braking * deltaTime);
    // } else {
    //   horizontalVel      = Vector2.ClampMagnitude(horizontalVel + direction * acceleration * deltaTime, maxSpeed);
    //   transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Runner.DeltaTime);
    // }

    moveVelocity.x = direction.x * speed;
    moveVelocity.y = direction.y * speed;
    rigidbody2D.velocity = new Vector2(moveVelocity.x, moveVelocity.y);
    Debug.Log(rigidbody2D.velocity);

    // Velocity   = (transform.position - previousPos) * Runner.Simulation.Config.TickRate;
  }
}