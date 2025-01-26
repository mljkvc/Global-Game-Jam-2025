using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Za rad sa UI komponentama
using UnityEngine.SceneManagement;

using TMPro;

public class ArmController : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 targetPosition;
    private bool flag = false;
    private bool flagCobra = false;
    private float startingY;
    private bool hasReachedTarget = false; // Zastavica za praćenje kraja igre

    public Animator animator;

    public FallingObjectSpawner spawner; // Referenca na FallingObjectSpawner
    public static float LastElapsedTime;
    // Tajmer promenljive
    private float elapsedTime = 0f; // Proteklo vreme igre
    public TMP_Text timerText; // Referenca na UI Text komponentu za prikaz vremena

    public static ArmController instance
    {
        get; private set;
    }

    void Awake()
    {
        if (instance == null)
        {
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

        // Inicijalizacija tajmera
        elapsedTime = 0f; // Resetuj vreme
    }

    void Update()
    {
        if (hasReachedTarget) return; // Ako je cilj dostignut, prekidamo Update

        // Ažuriraj tajmer
        UpdateTimer();

        CheckIfAtTarget();

        if (flag)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 12 * -speed * Time.deltaTime);
            if (transform.position.y < startingY)
            {
                transform.position = new Vector3(transform.position.x, startingY, transform.position.z);
            }
            return;
        }

        if (flagCobra)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 40 * -speed * Time.deltaTime);
            if (transform.position.y < startingY)
            {
                transform.position = new Vector3(transform.position.x, startingY, transform.position.z);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    public void MoveHandDown()
    {
        if (hasReachedTarget) return; // Ako je cilj dostignut, nemoj pozivati više ovu funkciju

        flag = true;
        StartCoroutine(delay());




        Debug.Log("HandDown metoda se poziva. Trenutna pozicija: " + transform.position);

    }

    public void MoveHandDownCobra()
    {
        if (hasReachedTarget) return; // Ako je cilj dostignut, nemoj pozivati više ovu funkciju

        flagCobra = true;
        StartCoroutine(delay());

        Debug.Log("HandDownCobra metoda se poziva. Trenutna pozicija: " + transform.position);

    }

    private void CheckIfAtTarget()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            Debug.Log("Kraj! Ruka je stigla do ciljne pozicije: " + targetPosition);

            hasReachedTarget = true;

            // Zaustavi spawning objekata ako postoji referenca na spawner
            if (spawner != null)
            {
                spawner.StopSpawning();
            }

            EndGame(); // Zaustavi igru
        }
    }

    private void UpdateTimer()
    {
    elapsedTime += Time.deltaTime;

    // Proračunaj minute i sekunde
    int minutes = Mathf.FloorToInt(elapsedTime / 60);
    int seconds = Mathf.FloorToInt(elapsedTime % 60);

    // Prikaz vremena u UI Text komponenti
    if (timerText != null)
    {
        // Formatiraj prikaz kao mm:ss
        timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }
    }


    private void EndGame()
    {
        hasReachedTarget = true; // Zaustavi Update
        LastElapsedTime = elapsedTime;
        // Zaustavi spawning objekata
        if (spawner != null)
        {
            spawner.StopSpawning();
        }
        //obfr zovi animaciju
        animator.SetTrigger("Uticnica"); 

        StartCoroutine(DelayAndSwitchScene());
        // Prikazi poruku kraja igre (opciono)
        Debug.Log("Game Over! Ukupno vreme igranja: " + Mathf.FloorToInt(elapsedTime).ToString() + " sekundi.");
    }

    IEnumerator DelayAndSwitchScene()
    {
        Debug.Log("jebem si majku");
        yield return new WaitForSeconds(3.69f);
        SceneManager.LoadScene(2);
    }
}
