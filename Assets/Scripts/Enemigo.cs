using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Rigidbody rb;

    public Quaternion angulo; // Ángulo para rotar al enemigo
    public Animator animator; // Controlador de animaciones
    public float speed = 2f;
    public Transform player; // Indica posicion del jugador
    public float radioDeteccion = 5f;

    public float radioAtaque = 1.5f;
    public float tiempoDeAtaque = 1f; // Tiempo entre ataques
    public int dañoAtaque = 10; // Daño del ataque

    private Vector3 movimiento; // Dirección
    private float tiempoUltimoAtaque; // Temporizador para el ataque

    // Patrullar
    private Vector3 puntoDestino;
    private float tiempoDeCambioDestino = 3f; // Tiempo antes de cambiar de destino
    private float tiempoUltimoCambio = 0f; // Temporizador para el cambio de destino
    public float distanciaMinimaParaParar = 0.1f; // Para que no vibre

    // Nueva variable para controlar si el enemigo está quieto
    private bool estaQuieto = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        CambiarDestino(); // Inicializamos
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el enemigo está quieto, desactivar cualquier animación de caminar
        if (estaQuieto)
        {
            animator.SetBool("walk", false);
            return;
        }

        if (distanceToPlayer < radioDeteccion) // Dentro del rango de detección
        {
            Vector3 direction = (player.position - transform.position).normalized;
            movimiento = new Vector3(direction.x, 0, direction.z);

            // Giro
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 200 * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0); // Solo en el eje Y

            // Activa la animación de caminar
            animator.SetBool("walk", true);

            if (distanceToPlayer < radioAtaque) // Dentro de rango de ataque
            {
                AtacarJugador();
            }
        }
        else // Si está fuera del rango
        {
            // Patrullaje
            float distanciaADestino = Vector3.Distance(transform.position, puntoDestino);
            if (distanciaADestino > distanciaMinimaParaParar)
            {
                MoverseHaciaPunto(puntoDestino);
                animator.SetBool("walk", true);
            }
            else
            {
                // Si está cerca del punto, se detiene y espera un nuevo destino
                movimiento = Vector3.zero;
                animator.SetBool("walk", false);

                // Cambiar destino después de un cierto tiempo
                if (Time.time - tiempoUltimoCambio > tiempoDeCambioDestino)
                {
                    CambiarDestino();
                    tiempoUltimoCambio = Time.time;
                }
            }
        }

        // Aplica el movimiento
        transform.position += movimiento * speed * Time.deltaTime;
    }

    void AtacarJugador()
    {
        // Verifica si ha pasado el tiempo suficiente para un nuevo ataque
        if (Time.time - tiempoUltimoAtaque >= tiempoDeAtaque)
        {
            tiempoUltimoAtaque = Time.time;
            // Llama al ataque en el Animator (asegúrate de tener un trigger de "Attack" en el Animator)
            animator.SetTrigger("attack");
        }
    }

    void CambiarDestino() // Patrullaje aleatorio si no detecta al player
    {
        float x = transform.position.x + Random.Range(-3f, 3f); // Rango aleatorio en el eje X
        float z = transform.position.z + Random.Range(-3f, 3f); // Rango aleatorio en el eje Z
        puntoDestino = new Vector3(x, transform.position.y, z);
    }

    // Mueve al enemigo hacia el punto de destino
    void MoverseHaciaPunto(Vector3 destino)
    {
        Vector3 direction = (destino - transform.position).normalized;
        movimiento = new Vector3(direction.x, 0, direction.z);
    }

    // Método público para hacer que el enemigo se quede quieto
    public void EstarQuieto(bool idle)
    {
        estaQuieto = idle;
    }

    private void OnDrawGizmosSelected()
    {
        // Permite ver el rango de detección y el rango de ataque
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioAtaque);
    }
}
