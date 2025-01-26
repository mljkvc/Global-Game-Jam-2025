using System.Collections;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 targetPosition;
    bool flag = false;
    bool flagCobra = false;
    float startingY;
    public static ArmController instance {

        get; private set;
    }


    void Awake()
    {
        if (instance == null) { 
            instance = this;
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.2f);
        flag = false;
        flagCobra = false;
    }

    void Start()
    {
        targetPosition = new Vector3(transform.position.x, -2f, transform.position.z);
        startingY = transform.position.y;
    }

    void Update()
    {
        CheckIfAtTarget();
        if (flag)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 12 * -speed * Time.deltaTime);
            if(transform.position.y < startingY)
            {
                transform.position = new Vector3(transform.position.x, startingY, transform.position.z);
            }
            return;
        }
        if (flagCobra)
           {
               transform.position = Vector3.MoveTowards(transform.position, targetPosition,40 *  -speed * Time.deltaTime);
            if (transform.position.y < startingY)
            {
                transform.position = new Vector3(transform.position.x, startingY, transform.position.z);
            }
        }
        else {
             transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
              }

    }
    public void MoveHandDown()
    {
        flag = true;
        StartCoroutine(delay());
        Debug.Log("mikac");
        // Pomeraj ruku prema dole sa određenom brzinom
        Debug.Log("HandDown metoda se poziva. Trenutna pozicija: " + transform.position);

       // transform.position -= new Vector3(0, 3f,0);
        Debug.Log(" NAKON HandDown metoda se poziva. Trenutna pozicija: " + transform.position);

    }
    public void MoveHandDownCobra()
    {
        flagCobra = true;
        StartCoroutine(delay());
        Debug.Log("mikac");
        // Pomeraj ruku prema dole sa određenom brzinom
        Debug.Log("HandDown metoda se poziva. Trenutna pozicija: " + transform.position);

        // transform.position -= new Vector3(0, 3f,0);
        Debug.Log(" NAKON HandDown metoda se poziva. Trenutna pozicija: " + transform.position);

    }
        private void CheckIfAtTarget()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            Debug.Log("Kraj! Ruka je stigla do ciljne pozicije: " + targetPosition);
        }
    }
}
