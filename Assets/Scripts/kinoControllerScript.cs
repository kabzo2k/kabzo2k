using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kinoControllerScript : MonoBehaviour
{
    public Rigidbody kinokoRB;
    GameObject FinishPoint;

    [SerializeField]
    float goingCounter;

    float counter = 0;

    [SerializeField]
    string targetName;

    [SerializeField]
    float jumpPow;

    [SerializeField]
    float forwardPow;



    void Start()
    {
        kinokoRB.WakeUp();
        kinokoRB.centerOfMass = new Vector3(0, 0, 0);
        FinishPoint = GameObject.FindGameObjectWithTag(targetName);
    }

    void Update()
    {
        yureCan();
        counter += Time.deltaTime;
        if (counter > goingCounter)
        {
            lottery();
        }

    }

    void lottery()
    {
        switch (Random.Range(0, 6))
        {
            case 1:
                Debug.Log("Ahead");
                StartCoroutine("kinoAhead");//タゲを向く
                counter = Random.Range(-1.0f, 0.0f);
                break;

            case 2:
                Debug.Log("forward");
                kinokoRB.AddForce(transform.forward * forwardPow, ForceMode.Impulse);//前方移動
                counter = Random.Range(-1.0f, 0.0f);
                break;

            case 3:
                Debug.Log("jump");
                kinokoRB.AddForce(transform.up * jumpPow, ForceMode.Impulse);//ジャンプ
                kinokoRB.AddForce(transform.forward * forwardPow/2, ForceMode.Impulse);
                kinokoRB.AddTorque(Vector3.up * Random.Range(-0.3f, 0.3f), ForceMode.Impulse);
                kinokoRB.AddTorque(Vector3.forward * Random.Range(-1.0f, 1.0f), ForceMode.Impulse);
                kinokoRB.AddTorque(Vector3.right * Random.Range(-1.0f, 1.0f), ForceMode.Impulse);
                counter = Random.Range(-1.0f, 0.0f);
                break;

            case 4:
                Debug.Log("forward");
                kinokoRB.AddForce(transform.forward * forwardPow, ForceMode.Impulse);//前方移動
                counter = Random.Range(-1.0f, 0.0f);
                break;

            case 5:
                Debug.Log("wait");
                //待機
                counter = Random.Range(-1.0f, 0.0f);
                break;


            //デフォルト処理
            default:
                counter = 0 - Random.Range(0.0f, 2.0f);
                break;
        }
    }

    void yureCan()
    {
        if (kinokoRB.angularVelocity.x > 0.01f ||
    kinokoRB.angularVelocity.y > 0.01f ||
    kinokoRB.angularVelocity.z > 0.01f
    )
        {
            kinokoRB.angularVelocity *= 0.9f;
        }
    }

    IEnumerator kinoAhead()
    {
        for(int i=0;i<20;i++)
        {
            float speed = 0.1f;
            Vector3 relativePos = FinishPoint.transform.position - this.transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);
            yield return new WaitForSeconds(0);
        }
    }

}
