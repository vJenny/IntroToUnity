using UnityEngine;
using System.Collections;
using System.ComponentModel;
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
    private bool _rightDir;

    // константы
    private const float CheckRatio = 0.2f;

    void Start()
    {
        _rightDir = true;
    }

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

        if (_hLocation > 0 && !_rightDir || _hLocation < 0 && _rightDir)
            Flip();
    }

    void Flip()
    {
        _rightDir = !_rightDir;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
