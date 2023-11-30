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

        anim.SetBool("IsWalking", true);
    }

    void Update()
    {
        if (Vector3.Distance(new Vector3(transform.position.x,0,transform.position.z), nodos[currentNodeIndex].transform.position) < 0.1f)
        {

            // Mantener la posición Y constante
            Vector3 newPosition = transform.position;
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

        StartCoroutine(MoveTowardsTarget(targetPosition));

        Debug.Log(currentNodeIndex);
    }

    IEnumerator MoveTowardsTarget(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, tiempoMove * Time.deltaTime);
            yield return null;
        }
    }
}

