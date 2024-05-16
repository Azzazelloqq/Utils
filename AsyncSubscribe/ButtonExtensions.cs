using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Utils.AsyncSubscribe
{
public static class ButtonExtensions
{
    public static IDisposable SubscribeClickAsync(this Button button, Func<CancellationToken, Task> onClickCallback, CancellationToken token = default)
    {
        var tcs = new TaskCompletionSource<bool>();

        async void OnClickHandler()
        {
            if (token.IsCancellationRequested)
            {
                button.onClick.RemoveListener(OnClickHandler);
                tcs.TrySetCanceled();
                return;
            }

            try
            {
                await onClickCallback(token);
                tcs.TrySetResult(true);
            }
            catch (Exception e)
            {
                if (e is not OperationCanceledException)
                {
                    Debug.LogException(e);
                }
                tcs.TrySetException(e);
            }
        }

        button.onClick.AddListener(OnClickHandler);

        return new Unsubscriber(() =>
        {
            button.onClick.RemoveListener(OnClickHandler);
            tcs.TrySetCanceled();
        });
    }
}
}