using System.Collections;
using UnityEngine;

public class UnlockingWallJump : MonoBehaviour

{
    [SerializeField] GameObject particles;
    [SerializeField] GameObject canvasUI;

    bool used;
    void Start()
    {
        if(PlayerController.Instance.unlockedWallJump)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !used)
        {
            used = true;
            StartCoroutine(ShowUI());
        }
    }
    IEnumerator ShowUI()
    {
        GameObject _particles = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(_particles, 0.5f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);

        canvasUI.SetActive(true);

        yield return new WaitForSeconds(4f);
        PlayerController.Instance.unlockedWallJump = true;
        canvasUI.SetActive(false);
        Destroy(gameObject);
    }
}
