using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class heroScript : MonoBehaviour
{
    // переменные, доступные в Unity
    public float MaxSpeed = 10f;
    public LayerMask Ground;
    public float HLocation;
    public Transform GroundDetector;

    // вспомогательные переменные

    // константы

    void Start () { }

    void FixedUpdate()
    {
        HLocation = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        var hero = GetComponent<Rigidbody2D>();
        hero.velocity = new Vector2(HLocation * MaxSpeed, hero.velocity.y);
    }
}
