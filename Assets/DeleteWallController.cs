using UnityEngine;
using System.Collections;

public class DeleteWallController : MonoBehaviour
{
    //unitychanちゃんのオブジェクト
    private GameObject unitychan;
    //DeleteWallちゃんとunitychanの距離
    private float difference;

    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //UnityちゃんとDeleteWallの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置に合わせてDeleteWallの位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }

    //トリガーモードで他のオブジェクトと接触した場合の処理（追加）
    void OnTriggerEnter(Collider other)
    {
        //コインに衝突した場合（追加）
        if (other.gameObject.tag == "CoinTag")
        {
            //接触したコインのオブジェクトを破棄（追加）
            Destroy (other.gameObject);
        }

        //車もしくはコーンに衝突した場合
        else if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            //接触した車もしくはコーンのオブジェクトを破棄（追加）
            Destroy (other.gameObject);
        }


    }
}