
interface IFlowListener
{
	void OnReciveFlow(bool flow);
}

interface IActivationListener
{
	void OnReciveActivation(bool isActivate, bool isOneShot);
}
