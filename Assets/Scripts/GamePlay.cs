using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public int[] passwords;
    public int findPassword = 0;

    public AudioClip collect;
    // Start is called before the first frame update
    void Start()
    {
        passwords = Generate_Paswwords();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Indice"))
        {
            GetComponent<AudioSource>().PlayOneShot(collect);
            other.gameObject.SetActive(false);
            findPassword++;
        }
    }
    int[] Generate_Paswwords()
    // Update is called once per frame
    // void Update()
    {
        int[] arr_pass = new int[4];
        for (int i = 0; i < 4; i++)
        {
            arr_pass[i] = Random.Range(0, 9);
        }
        return arr_pass;
    }
}
