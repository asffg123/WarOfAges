using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CooldownTimer;

public class Entity : MonoBehaviour
{
    // HP Field
    public uint currentHpField;
    public uint maxHpField;
    [System.NonSerialized]
    public Health hpBar;

    // Cooldown
    public Cooldown attackCooldown;

    // Team field
    public TeamID team;

    // Color field
    private Color defaultColor;
    private SpriteRenderer spriteRenderer;
    public Color attackColor;
    public Color hurtColor;

    // Unit direction for movement
    public Vector2 FacingDirection;

    // Unit speed
    public float MovementSpeed;
    [System.NonSerialized]
    public float EffectiveSpeed;

    // Detector call
    [System.NonSerialized] // Not in editor
    public Detect Detector;

    // Adding Rigidbody not serialized
    [System.NonSerialized]
    public Rigidbody2D Rbody;

    // Start is called before the first frame update
    void Start()
    {
        // Searches for rigidbody and sets it
        Rbody = gameObject.GetComponent<Rigidbody2D>();

        // Searches for detector
        Detector = GetComponentInChildren<Detect>();

        // Finds collider
        Detector.selfCollider = GetComponent<Collider2D>();

        // Finds hp bar
        hpBar = GetComponent<Health>();
        hpBar.UpdateText(currentHpField, maxHpField);

        // Finds spriterender, sets default color
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If entity was detected within detector
        if (Detector.unitDetector() != TeamID.none)
        {
            EffectiveSpeed = 0;
            
            if (Detector.unitDetector() != this.team)
            {
                if (attackCooldown.IsReady)
                {
                    StartCoroutine(Attack());
                    attackCooldown.Use();
                }
            }
        }
        else
            EffectiveSpeed = MovementSpeed;

        // Unit is allowed to move in a direction
        Vector2 velocity = Rbody.velocity;
        velocity.x = FacingDirection.x * EffectiveSpeed;
        Rbody.velocity = velocity;
    }

    private IEnumerator Attack()
    {
        spriteRenderer.color = attackColor;
        yield return new WaitForSeconds(1);

        spriteRenderer.color = defaultColor;
    }
}

[System.Serializable]
public enum TeamID
{
    none, 
    playerTeam, 
    enemyTeam,
}
