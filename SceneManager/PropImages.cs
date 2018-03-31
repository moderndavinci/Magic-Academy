using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropImages : ManagerScene<PropImages> {

    public List<int> props = new List<int>();
	public void PasteProp(int _index)
    {
        props.Add(_index);
    }
}
