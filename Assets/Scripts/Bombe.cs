using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Bombe : MonoBehaviour
{
    public TMP_Text leftTime;
    public TMP_Text indice;
    public GameObject player;
    public TMP_Text GameOver;
    public TMP_Text Victory;
    // public Text leftTime;
    public float baseChrono = 100;
    float chrono = 0;
    bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        chrono = baseChrono;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            chrono -= Time.deltaTime;
            leftTime.text = Mathf.RoundToInt(chrono).ToString() + "s";
            if (chrono <= 0)
            {
                active = false;
            }
            if (chrono <= 10)
            {
                leftTime.color = Color.green;
            }
        }
        if (chrono <= 0)
        {
            active = false;
            GameOver.gameObject.SetActive(true);
            StartCoroutine(waitScene(0));
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            if (player.GetComponent<GamePlay>().findPassword == 4 )
            {
                if (PlayerPrefs.HasKey("bestScore"))
                {
                    if (PlayerPrefs.GetInt("bestScore") > (baseChrono - chrono))
                        PlayerPrefs.SetInt("bestScore", (int)(baseChrono - chrono));
                }
                else
                    PlayerPrefs.SetInt("bestScore", (int)(baseChrono - chrono));

                indice.text = "Bombe désactivée";
                active = false;
                Victory.gameObject.SetActive(true);
                StartCoroutine(waitScene(0));
                // SceneManager.LoadScene(0);
            }
            else if(active)
                indice.text = "vous devez collectionner les indices pour déactiver la bombe";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            indice.text = "";
        }
    }

    IEnumerator waitScene(int scene) // les scnènes sont numérotées dans l'ordre de création ( setting > )
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(scene);
    }
}
