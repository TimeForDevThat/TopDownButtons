using System.Collections.Generic;
using UnityEngine;

public class BaseBaff: MonoBehaviour {
    public List<Baff> Baffs;
}

[System.Serializable]
public class Baff {
    public string InfoName;
    public Sprite IconImage;
    public Color color;
}