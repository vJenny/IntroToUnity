using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class heroScript : MonoBehaviour
{
    // переменные, доступные в Unity
    public float MaxSpeed = 10f;
    public LayerMask Ground;
    public Transform GroundDetector;

    public float JumpForce = 500f;

    // вспомогательные переменные
    private float _hLocation;
    private bool _grounded;

    // константы
    private const float CheckRatio = 0.2f;

    void Start () { }

    void FixedUpdate()
    {
        _grounded = Physics2D.OverlapCircle(GroundDetector.position, CheckRatio, Ground); // определяем пересечение с землей
        _hLocation = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        var hero = GetComponent<Rigidbody2D>();

        if (_grounded && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)))
            hero.AddForce(new Vector2(0f, JumpForce)); // добавляем движение вверх, 0 по оси Ох

        hero.velocity = new Vector2(_hLocation * MaxSpeed, hero.velocity.y);
    }
}
