using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class magicattack : MonoBehaviour
{
    public GameObject s;
    public GameObject target;
    GameObject throwing;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("enemy1");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            throwing = Instantiate<GameObject>(s, transform.position, Quaternion.identity, target.transform);
        }
        Vector3 direction = target.transform.position - transform.position;
        if (throwing != null)
        {
            throwing.transform.position += direction.normalized * Time.deltaTime * 200;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Destroy(throwing);
        }
    }
}
