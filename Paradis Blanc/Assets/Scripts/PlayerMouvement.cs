using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer lightSprite;
    private SpriteRenderer lightSprite2;
    private SpriteRenderer lightSprite3;


    [SerializeField] private Color invincibilityColor;
    [SerializeField] private Color invincibilityColorLight;
    [SerializeField] private Color ColorLight;
    [SerializeField] private float invincibilityTime;
    [SerializeField] private bool invincibilityShake;
    private bool invincibility;
    public bool Invincibility => invincibility;
    [SerializeField] private GameObject Light;
    [SerializeField] private GameObject Light2;
    [SerializeField] private GameObject Light3;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    [SerializeField] private float airMax;
    public float AirMax => airMax;
    
    [SerializeField] private float decreaseAir;
    private float actualAir;
    public float ActualAir => actualAir;

    private AudioSource CarburantSound;
       
    public CameraShake CameraShake;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        CarburantSound = GetComponent<AudioSource>();
        actualAir = airMax;
        lightSprite = Light.GetComponentInChildren<SpriteRenderer>();
        lightSprite2 = Light2.GetComponentInChildren<SpriteRenderer>();
        lightSprite3 = Light3.GetComponentInChildren<SpriteRenderer>();
    }
    
    void Update()
    {
        if (Input.GetButton("Jump") || Input.touchCount>0)
        {
            rigidbody2D.AddForce(Vector2.down*speed);
        }

        if (Mathf.Abs(rigidbody2D.velocity.y) > maxSpeed)
        {
            rigidbody2D.velocity = new Vector2(0, maxSpeed * Mathf.Sign(rigidbody2D.velocity.y));
        }

        if (rigidbody2D.velocity.y > 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, 10);
        } else if (rigidbody2D.velocity.y < -2)
        {
            transform.rotation = Quaternion.Euler(0, 0, -10);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (actualAir <= 25f/100 * airMax )
        {
            actualAir -= decreaseAir * Time.deltaTime/2;
        }
        else
        {
            actualAir -= decreaseAir * Time.deltaTime;
        }
        if (actualAir <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        LivesManagement.Instance.Health = 0;
    }

    public IEnumerator InvincibilityCouroutine()
    {
        spriteRenderer.color = invincibilityColor;
        lightSprite.color = invincibilityColorLight;
        lightSprite2.color = invincibilityColorLight;
        lightSprite3.color = invincibilityColorLight;
        invincibility = true;
        GameManager.Instance.Speed /= 2;
        yield return new WaitForSeconds(1);
        GameManager.Instance.Speed *= 2;
        yield return new WaitForSeconds(invincibilityTime);
        invincibility = false;
        spriteRenderer.color = Color.white;
        lightSprite.color = ColorLight;
        lightSprite2.color = ColorLight;
        lightSprite3.color = ColorLight;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Carburant"))
        {
            actualAir = airMax;
            CarburantSound.Play();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            CameraShake.ShakeFonction(.15f,.4f);

        }
    }
}
