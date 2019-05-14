using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour {

    public GameObject diamonds;
    // Use this for initialization
    void Start() {

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Invoke("FallDown", 0.8f);
            // FallDown();
        }
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;

        Destroy(transform.parent.gameObject, 2f);
    }
}
