using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteController : MonoBehaviour
{
    public NodeController[] nodos;
    public float tiempoMove = 0.5f;

    private int currentNodeIndex = 0;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (nodos.Length > 0)
        {
            MoveToNextNode();
        }
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, nodos[currentNodeIndex].transform.position) < 0.1f)
        {
            anim.SetBool("IsWalking", false);

            // Mantener la posición Y constante
            Vector3 newPosition = transform.position;
            newPosition.y = -76.0f;
            transform.position = newPosition;

            MoveToNextNode();
        }
    }

    void MoveToNextNode()
    {
        if (nodos.Length == 0)
        {
            return;
        }

        currentNodeIndex = (currentNodeIndex + 1) % nodos.Length;

        Vector3 targetPosition = nodos[currentNodeIndex].transform.position;

        anim.SetBool("IsWalking", true);

        StartCoroutine(MoveTowardsTarget(targetPosition));

        Debug.Log(currentNodeIndex);
    }

    System.Collections.IEnumerator MoveTowardsTarget(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, tiempoMove * Time.deltaTime);
            yield return null;
        }
    }
}

