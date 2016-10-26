using UnityEngine;

public class cameraScript : MonoBehaviour
{ 
    public GameObject Hero;
    private Vector3 _offset;         
    
    void Start()
    {
        // вычисляем отступ между позицией героя и позицией камеры
        _offset = transform.position - Hero.transform.position;
    }
    
    void LateUpdate()
    {
        // устанавливаем позицию камеры такую же, как у героя, учитывая исходный отступ
        transform.position = Hero.transform.position + _offset;
    }
}
