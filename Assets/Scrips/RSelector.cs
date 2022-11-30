using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSelector : Node
{
    bool shaffled = false;
    public RSelector(string n)
    {
        name = n;
    }
    
    public override Status Process()
    {
        if (!shaffled)
        {
            children.Shuffle();
            shaffled = true;
        }
        
        Status childstatus = children[currentChild].Process();
        if (childstatus == Status.RUNNING)
            return Status.RUNNING;

        if (childstatus == Status.SUCCESS)
        {
            currentChild = 0;
            shaffled = false;
            return Status.SUCCESS;
        }
        

        currentChild++;
        if (currentChild >= children.Count)
        {
            currentChild = 0;
            shaffled = false;
            return Status.FAILURE;
        }

        return Status.RUNNING;
    }
}
