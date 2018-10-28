using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour {

    private int isConversing=0;

    public int getIsConversing()
    {
        return isConversing;
    }
    public void setIsConversing(int i)
    {
        isConversing=i;
    }
    
}
