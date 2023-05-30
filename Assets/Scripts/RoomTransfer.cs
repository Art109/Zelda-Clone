using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransfer : MonoBehaviour
{
    //Att Limite da Camera
    Camera_Movement cam;
    [SerializeField]Vector2 cameraChange;
    [SerializeField]Vector3 playerChange;

    //Indicador de mapa
    [SerializeField] Text placeText;
    [SerializeField] GameObject text;
    [SerializeField] string placeName;
    [SerializeField]bool willChange;


    void Start()
    {
        cam = Camera.main.GetComponent<Camera_Movement>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cam.maxPosition += cameraChange;
            cam.minPosition += cameraChange;
            collision.transform.position += playerChange;

            if(willChange)
            {
                StartCoroutine(ShowPlaceName());
            }
        }
    }

    IEnumerator ShowPlaceName()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
        yield return null;
    }
}
