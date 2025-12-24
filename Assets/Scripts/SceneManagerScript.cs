using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] private int relodeTime =3;

    public void RelodeScene()
    {
        StartCoroutine(RelodeAfterSec());
    }
    IEnumerator RelodeAfterSec()
    {
        yield return new WaitForSeconds(relodeTime);
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

}
