using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] GameObject startLine;
    [SerializeField] GameObject finishLine;

    Image progressBar;
    float maxDistance;

    private void Start()
    {
        progressBar = GetComponent<Image>();
        maxDistance = finishLine.transform.position.z;
        progressBar.fillAmount = startLine.transform.position.z / maxDistance;
    }

    private void Update()
    {
        if (progressBar.fillAmount < 1)
        {
            progressBar.fillAmount = startLine.transform.position.z / maxDistance;
        }
    }




}
