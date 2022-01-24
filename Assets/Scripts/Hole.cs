using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public string targetTag;
    bool isholding;

    public bool IsHolding()
    {
        return isholding;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            isholding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            isholding = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        Vector3 direction = other.transform.position - transform.position;
        direction.Normalize();

        if (other.CompareTag(targetTag))
        {
            rb.velocity *= 0.9f; // ���S�ő��x�����������邽�߂̋L�q
            rb.AddForce(direction * -20f, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(direction * 80f, ForceMode.Acceleration);
        }
    }
}
