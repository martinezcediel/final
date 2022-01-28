using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Vector3 targetPos;
    private float speed;
    private float totalSeconds = 1; // Duraci�n total del movimiento
    private float totalDistance = 1; // 4m a recorrer
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Limites de Tablero
        if(transform.position.x < -5.5)
        {
            transform.position = new Vector3(-5.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 5.5)
        {
            transform.position = new Vector3(5.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -0.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        }
        if (transform.position.z > 17.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 17.5f);
        }

        //Movimiento del Personaje
        if (!isMoving && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 RotForward = new Vector3(-90f, 0f, 0f);
            transform.rotation = Quaternion.Euler(RotForward);
            targetPos = transform.position + totalDistance * Vector3.forward;
            StartCoroutine(Move(targetPos, totalSeconds));
        }

        if (!isMoving && Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 RotBack = new Vector3(-90f, 0f, 180f);
            transform.rotation = Quaternion.Euler(RotBack);
            targetPos = transform.position + totalDistance * Vector3.back;
            StartCoroutine(Move(targetPos, totalSeconds));
        }

        if (!isMoving && Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 RotRight = new Vector3 (-90f, 0f, 90f);
            transform.rotation = Quaternion.Euler(RotRight);
            targetPos = transform.position + totalDistance * Vector3.right;
            StartCoroutine(Move(targetPos, totalSeconds));
        }

        if (!isMoving && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 RotLeft = new Vector3(-90f, 0f, -90f);
            transform.rotation = Quaternion.Euler(RotLeft);
            targetPos = transform.position + totalDistance * Vector3.left;
            StartCoroutine(Move(targetPos, totalSeconds));
        }
    }

    private IEnumerator Move(Vector3 targetPosition, float duration)
    {
        if (isMoving) yield break; // Si nos estamos moviendo, nada

        // Si est�bamos quietos, iniciamos movimiento
        isMoving = true;

        // Configuramos la velocidad en funci�n de la distancia a recorrer y el tiempo total del recorrido
        speed = Vector3.Distance(transform.position, targetPos) / totalSeconds;
        float passedTime = 0f;

        // Mientras el tiempo transcurrido no supere la duraci�n total, nos movemos hacia targetPos
        while (passedTime < duration)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos,
                speed * Time.deltaTime);

            // Aumentamos el tiempo transcurrido
            passedTime += Time.deltaTime;

            // Pasamos al siguiente frame
            yield return null;

        }

        // Al acabar, nos aseguramos de que nuestra posici�n, sea la posici�n objetivo
        transform.position = targetPosition;
        // Ya no nos movemos
        isMoving = false;
    }
}

