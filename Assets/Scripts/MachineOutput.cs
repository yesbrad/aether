using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineOutput : MachineInteractor
{
	public override void Init(Pipe pipe)
	{
		base.Init(pipe);
		machineBlock.AddInteractor(this, MachineBlock.BlockInteractors.MachineOutput);
	}
}

public class MachineInput : MachineInteractor
{
	public override void Init(Pipe pipe)
	{
		base.Init(pipe);
		machineBlock.AddInteractor(this, MachineBlock.BlockInteractors.MachineInput);
	}
}


public class UtilityOutput : MachineInteractor
{
	public override void Init(Pipe pipe)
	{
		base.Init(pipe);
		machineBlock.AddInteractor(this, MachineBlock.BlockInteractors.UtilityOuput);
	}
}

public class UtilityInput : MachineInteractor
{
	public override void Init(Pipe pipe)
	{
		base.Init(pipe);
		machineBlock.AddInteractor(this, MachineBlock.BlockInteractors.UtilityInput);
	}
}

