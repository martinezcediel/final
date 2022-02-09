using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Vector3 targetPos;
    private float speed;
    private float totalSeconds = 1; // Duración total del movimiento
    private float totalDistance = 1; // 4m a recorrer
    private bool isMoving;
    private walls wallsscript; // Llamo al script de walls

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        wallsscript = GetComponent<walls>();
    }

    // Update is called once per frame
    void Update()
    {

        // Movimiento del Personaje
        if (!isMoving && Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Rotacion al moverse
            Vector3 RotForward = new Vector3(-90f, 0f, 0f);
            transform.rotation = Quaternion.Euler(RotForward);
            targetPos = transform.position + totalDistance * Vector3.forward;

            // Si la pared NO en la Target Position, se inicia la Corutina 
            if(wallsscript.isValidPosition(targetPos))
            {
            StartCoroutine(Move(targetPos, totalSeconds));
            }
            
            
        }

        if (!isMoving && Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 RotBack = new Vector3(-90f, 0f, 180f);
            transform.rotation = Quaternion.Euler(RotBack);
            targetPos = transform.position + totalDistance * Vector3.back;
           

            if (wallsscript.isValidPosition(targetPos))
            {
                StartCoroutine(Move(targetPos, totalSeconds));
            }
        }

        if (!isMoving && Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 RotRight = new Vector3 (-90f, 0f, 90f);
            transform.rotation = Quaternion.Euler(RotRight);
            targetPos = transform.position + totalDistance * Vector3.right;
           

            if (wallsscript.isValidPosition(targetPos))
            {
                StartCoroutine(Move(targetPos, totalSeconds));
            }
        }

        if (!isMoving && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 RotLeft = new Vector3(-90f, 0f, -90f);
            transform.rotation = Quaternion.Euler(RotLeft);
            targetPos = transform.position + totalDistance * Vector3.left;
           

            if (wallsscript.isValidPosition(targetPos))
            {
                StartCoroutine(Move(targetPos, totalSeconds));
            }
        }
    }

    

    private IEnumerator Move(Vector3 targetPosition, float duration)
    {
        if (isMoving) yield break; // Si nos estamos moviendo, nada

        // Si estábamos quietos, iniciamos movimiento
        isMoving = true;

        // Configuramos la velocidad en función de la distancia a recorrer y el tiempo total del recorrido
        speed = Vector3.Distance(transform.position, targetPos) / totalSeconds;
        float passedTime = 0f;

        // Mientras el tiempo transcurrido no supere la duración total, nos movemos hacia targetPos
        while (passedTime < duration)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos,
                speed * Time.deltaTime);

            // Aumentamos el tiempo transcurrido
            passedTime += Time.deltaTime;

            // Pasamos al siguiente frame
            yield return null;

        }

        // Al acabar, nos aseguramos de que nuestra posición, sea la posición objetivo
        transform.position = targetPosition;
        // Ya no nos movemos
        isMoving = false;
    }
}

