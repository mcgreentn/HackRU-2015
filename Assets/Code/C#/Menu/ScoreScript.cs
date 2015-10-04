using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    public GameObject title;
    public GameObject base1;
    public GameObject time;
    public GameObject collect;
    public GameObject coins;
    public GameObject total;
    public GameObject next;
    
	// Use this for initialization
	void Start () {
        title.transform.position.Set(title.transform.position.x, title.transform.position.y - 2000, 0);
        base1.transform.position.Set(base1.transform.position.x + 1000, base1.transform.position.y, 0);
        time.transform.position.Set(time.transform.position.x + 1000, time.transform.position.y, 0);
        collect.transform.position.Set(collect.transform.position.x + 1000, collect.transform.position.y, 0);
        coins.transform.position.Set(coins.transform.position.x + 1000, coins.transform.position.y, 0);
        base1.transform.position.Set(base1.transform.position.x + 1000, base1.transform.position.y, 0);
        title.transform.position.Set(title.transform.position.x, title.transform.position.y + 1000, 0);

        WaitForSeconds(1.0);

    }

    // Update is called once per frame
    void Update () {
	
	}
}
