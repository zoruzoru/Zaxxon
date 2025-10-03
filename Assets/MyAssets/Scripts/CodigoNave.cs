using UnityEngine;

public class Codigo : MonoBehaviour
{
    [SerializeField] float smoothing = 0.5f;
    [SerializeField] float speed = 2f;

    Vector3 stopR;
    Vector3 currentR;
    Vector3 speedN = Vector3.zero;
    Vector3 centerpos = Vector3.zero;

    int rotatemax = 45;
    int vasculmax = 35;

    float moveX;
    float moveY;
    float desplR;

    void Start()
    {

    }

    void Update()
    {
        Movimiento();
        Rotaciones();
    }
    void Movimiento()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        Vector3 desplY = Vector3.up * Time.deltaTime * moveY * speed;
        transform.Translate(desplY, Space.World);

        Vector3 desplX = Vector3.right * Time.deltaTime * moveX * speed;
        transform.Translate(desplX, Space.World);

        Vector3 move = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;

        if (move.magnitude > 0.01f)
        {
            transform.Translate(move, Space.World);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, centerpos, ref speedN, smoothing);
        }
    }

    void Rotaciones()
    {
        desplR = Input.GetAxis("Rotar");

        stopR = new Vector3(0f, 0f, moveX * -rotatemax);
        currentR = Vector3.SmoothDamp(currentR, stopR, ref speedN, smoothing);

        transform.eulerAngles = currentR;
        
    }

}
