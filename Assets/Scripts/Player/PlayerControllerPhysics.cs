using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPhysics : MonoBehaviour
{
    [Header("Movimiento Horizontal")]
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje

    [Header("Movimiento Vertical")]
    public float jumpForce = 5f; // Fuerza de salto del personaje
    public float gravity = 9.8f; // Gravedad para movimientos verticales

    [Header("Inspector de Cinemática")]
    public float initialVelocityX = 0f; // Velocidad inicial en X editable desde el Inspector
    public float initialVelocityY = 0f; // Velocidad inicial en Y editable desde el Inspector
    public Vector2 initialPosition; // Posición inicial editable desde el Inspector

    private Animator animator; // Referencia al componente Animator
    private SpriteRenderer spriteRenderer; // Referencia al componente SpriteRenderer
    private Rigidbody2D rb; // Referencia al componente Rigidbody2D
    private bool isJumping = false; // Variable para controlar si el personaje está saltando

    // Variables para cálculos cinemáticos
    private float timeElapsed = 0f;
    private float displacementX = 0f;
    private float displacementY = 0f;
    private float velocityX = 0f;
    private float velocityY = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>(); // Obtener referencia al componente Animator
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtener referencia al componente SpriteRenderer
        rb = GetComponent<Rigidbody2D>(); // Obtener referencia al componente Rigidbody2D

        // Configurar la posición inicial desde el Inspector
        transform.position = new Vector3(initialPosition.x, initialPosition.y, 0);
        velocityX = initialVelocityX;
        velocityY = initialVelocityY;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime; // Incrementar el tiempo transcurrido

        // Movimiento horizontal
        float moveX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveX, 0f, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime; // Mover al personaje

        // Cálculo de desplazamiento y velocidad horizontal
        displacementX = transform.position.x - initialPosition.x;
        velocityX = moveX * moveSpeed;

        // Actualizar las variables del animator
        animator.SetFloat("MoveX", moveX);

        // Cambiar entre las animaciones IDLE y WALK
        if (Mathf.Abs(moveX) > 0f && !isJumping)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        // Cambiar la dirección del sprite según el movimiento
        if (moveX > 0f)
        {
            spriteRenderer.flipX = false; // No voltear el sprite horizontalmente
        }
        else if (moveX < 0f)
        {
            spriteRenderer.flipX = true; // Voltear el sprite horizontalmente
        }

        // Mecánica de salto y movimiento vertical
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            animator.SetTrigger("Jump"); // Activar la animación de salto
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }

        // Simular gravedad en el movimiento parabólico
        if (isJumping)
        {
            velocityY = rb.velocity.y;
            displacementY = transform.position.y - initialPosition.y;
            rb.velocity += Vector2.down * gravity * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            displacementY = 0f; // Reiniciar desplazamiento vertical al aterrizar
        }
    }

    private void OnGUI()
    {
        // Mostrar información cinemática en pantalla
        GUI.Label(new Rect(10, 10, 300, 20), "Tiempo transcurrido: " + timeElapsed.ToString("F2") + " s");
        GUI.Label(new Rect(10, 30, 300, 20), "Desplazamiento horizontal: " + displacementX.ToString("F2") + " m");
        GUI.Label(new Rect(10, 50, 300, 20), "Desplazamiento vertical: " + displacementY.ToString("F2") + " m");
        GUI.Label(new Rect(10, 70, 300, 20), "Velocidad horizontal: " + velocityX.ToString("F2") + " m/s");
        GUI.Label(new Rect(10, 90, 300, 20), "Velocidad vertical: " + velocityY.ToString("F2") + " m/s");
    }
}
