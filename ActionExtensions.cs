using System;

namespace Utils
{
public static class ActionExtensions
{
	public static void SubscribeOnce(this Action action, Action callback)
	{
		Action wrapper = null;
		wrapper = () =>
		{
			action -= wrapper;
			callback();
		};

		action += wrapper;
	}
}
}