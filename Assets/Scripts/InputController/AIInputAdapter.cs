using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputAdapter : IInputAdapter
{
    private AIController aiController;

    public AIInputAdapter(PlayerController playerController)
    {
        aiController = new AIController(playerController);
    }

    public bool IsPressingButtonA()
    {
        return aiController.ShouldPressButtonA();
    }

    public bool IsPressingButtonB()
    {
        return aiController.ShouldPressButtonB();
    }
}
