using System;

public class Node {

    private Object _Value;

    public Node()
    {
        _Value = false;
    }

    public Node(Object val)
    {
        _Value = val;
    }

    // Properties
    public Object Value
    {
        get { return _Value; }
        set { _Value = value; }
    }
}
