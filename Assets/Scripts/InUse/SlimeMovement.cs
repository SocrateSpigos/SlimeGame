using System.Collections;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public float Movespeed = 1.0f;

    private bool canMove;

    private void OnEnable()
    {
        StartCoroutine(StartMovement());
        SetRandomSize();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            this.transform.Translate(Vector3.up * Movespeed * Time.deltaTime);
        }
    }

    public IEnumerator StartMovement()
    {
        float wait = Random.Range(2, 4);
        yield return new WaitForSeconds(wait);
        canMove = true;
        float index = Random.Range(0.25f, 0.5f);
        yield return new WaitForSeconds(index);
        canMove = false;
        StartCoroutine(StartMovement());
    }

    private void SetRandomSize()
    {
        float scale = Random.Range(0.4f, 0.6f);
        transform.localScale = Vector3.one * scale;
    }

    public void StopMovement()
    {
        StopAllCoroutines();
        canMove = false;
    }
}
