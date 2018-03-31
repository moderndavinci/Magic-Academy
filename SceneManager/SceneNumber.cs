using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneNumber:ManagerScene<SceneNumber>{
    public string defualt;
    //场景名称
    public string depotShip = "DepotShip";
    public  string planet_1 = "Planet_1";
    public  string planet_2 = "Planet_2";
    public  string planet_3 = "Planet_3";
    public  string planet_4 = "Planet_4";
    public  string Loading = "Loading";

    //显示加载场景
    public void ChangScene(string name)
    {
        defualt = name;
        SceneManager.LoadScene(Loading);
    }
}
