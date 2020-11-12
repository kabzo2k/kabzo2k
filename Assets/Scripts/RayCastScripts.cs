using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScripts : MonoBehaviour
{
    public Camera ARcam;
    public GameObject prefab;
    public Rigidbody RB;
    public kinoControllerScript kinoConSC;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = ARcam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, 20.0f))
            {
                if (hit.collider.gameObject.tag == "target")
                {
                    Debug.Log("hithit!");

                    Vector3 pos = new Vector3(
                         hit.collider.gameObject.transform.position.x,
                         hit.collider.gameObject.transform.position.y + 1f,
                         hit.collider.gameObject.transform.position.z
                        );

                    GameObject bullet =
                    Instantiate(prefab,pos,Quaternion.identity);

                    RB.AddTorque(Vector3.up * Random.Range(-0.3f, 0.3f), ForceMode.Impulse);
                    RB.AddTorque(Vector3.forward * Random.Range(-1.0f, 1.0f), ForceMode.Impulse);
                    RB.AddTorque(Vector3.right * Random.Range(-1.0f, 1.0f), ForceMode.Impulse);
                    RB.AddForce(transform.up * 6 * Random.Range(-1.0f, 1.0f), ForceMode.Impulse);
                    RB.AddForce(transform.forward * 3 / 2, ForceMode.Impulse);

                }
            }

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 10);
        }
    }
}
