﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineOutput : MachineInteractor
{
	public override void Init(Pipe pipe)
	{
		base.Init(pipe);
		machineBlock.AddOutput(this);
	}
}
