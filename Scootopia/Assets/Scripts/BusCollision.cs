using UnityEngine;
using System.Collections;

public class BusCollision : MonoBehaviour
{
    public GameObject playerBody;
    public GameObject playerRagdollPrefab;
    public bool isRagdoll = false;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Bus") && !isRagdoll) {
            ConvertToRagdoll();
        }
    }

    private void ConvertToRagdoll() {
        GetComponent<TestController>().enabled = false;

        GameObject ragdoll = Instantiate(playerRagdollPrefab, playerBody.transform.position, playerBody.transform.rotation);
        ragdoll.transform.parent = transform;

        // Transfer the player's velocity to the ragdoll
        Rigidbody[] ragdollRigidbodies = ragdoll.GetComponentsInChildren<Rigidbody>();
        Rigidbody playerRigidbody = playerBody.GetComponent<Rigidbody>();
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.velocity = playerRigidbody.velocity;
        }

        Destroy(playerBody);

        isRagdoll = true;
    }
}
