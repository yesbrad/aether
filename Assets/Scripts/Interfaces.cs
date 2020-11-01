
interface IFlowListener
{
	void OnReciveFlow(GasType pipeType, bool flow);
}

interface IUtilityListener
{
	void OnReciveUtility(bool isOneShot);
}
