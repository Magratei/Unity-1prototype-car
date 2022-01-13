using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotation;
    private float rotationLeft;
    private float rotationUp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // получить вертикальный ввод пользователя
        rotationUp = Input.GetAxis("Vertical");
        rotationLeft = Input.GetAxis("Horizontal");

        // двигать самолет вперед с постоянной скоростью
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // наклонять самолет вверх / вниз на основе клавиш со стрелками вверх / вниз
        transform.Rotate(Vector3.up, rotationLeft * Time.deltaTime * rotation);
        transform.Rotate(Vector3.right, rotationUp * Time.deltaTime * rotation);
    }
}
