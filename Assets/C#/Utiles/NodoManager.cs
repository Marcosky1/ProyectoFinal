using UnityEngine;

public class NodoManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cliente") || other.CompareTag("ClientePreference"))
        {
            Cliente cliente = other.gameObject.GetComponent<Cliente>();

            if (cliente != null && !cliente.EsClienteSatisfecho())
            {
                Node nodo = GetComponent<Node>(); 

                if (nodo != null && !nodo.estaOcupado)
                {
                    nodo.estaOcupado = true;
                    cliente.NodoDestino = nodo;
                }
            }
        }
    }
}

