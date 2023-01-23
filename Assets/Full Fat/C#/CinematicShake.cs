using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicShake : MonoBehaviour
{
    public Camera cameraPlayer;

    float currentX;


    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 OriginalPos = cameraPlayer.transform.localPosition;
        currentX = OriginalPos.x;

        float elapsed = 0.00001f;

        while (elapsed < duration)
        {
            float x = Random.Range(cameraPlayer.transform.position.x - 8, cameraPlayer.transform.position.x + 8f) * magnitude;
            float y = Random.Range(cameraPlayer.transform.position.y - 8, cameraPlayer.transform.position.y + 8f) * magnitude;

            cameraPlayer.transform.localPosition = new Vector3( x + currentX, OriginalPos.y, OriginalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        cameraPlayer.transform.localPosition = OriginalPos;
    }






}
