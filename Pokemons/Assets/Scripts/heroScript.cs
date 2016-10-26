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

    public Sprite JumpingHero;
    public Sprite RunningHero;

    public float JumpForce = 500f;

    // вспомогательные переменные
    private float _hLocation;
    private float _vLocation;

    private bool _grounded;
    private bool _rightDir;

    private int _score;

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
        _vLocation = Input.GetAxis("Vertical");
    }

    void Update()
    {
        var hero = GetComponent<Rigidbody2D>();

        if (_grounded && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)))
            hero.AddForce(new Vector2(0f, JumpForce)); // добавляем движение вверх, 0 по оси Ох

        hero.velocity = new Vector2(_hLocation * MaxSpeed, hero.velocity.y);

        if (_hLocation > 0 && !_rightDir || _hLocation < 0 && _rightDir) // если направление движения и направление героя не совпадает - переворачиваем
            Flip();

        if (_vLocation > 0)
            Jump();
        if (_grounded)
            Run();
    }

    void Flip()
    {
        _rightDir = !_rightDir;
        var scale = transform.localScale; // отвечает за положение героя относительно своей оси
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Run()
    {
        GetComponent<SpriteRenderer>().sprite = RunningHero;
    }

    void Jump()
    {
        GetComponent<SpriteRenderer>().sprite = JumpingHero;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pokemon")
        {
            ++_score;
            Destroy(col.gameObject);
        }
    }

    void OnGUI()
    {
        GUI.backgroundColor = Color.gray;
        GUI.Box(new Rect(0, 0, 100, 100), "Score: " + _score);
    }

}
