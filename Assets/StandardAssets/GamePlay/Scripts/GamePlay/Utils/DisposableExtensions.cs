using System;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Utils
{
    public static class DisposableExtensions
    {
        public static void AddTo(this IDisposable disposable, Disposer disposer)
        {
            disposer.Add(disposable);
        }
    }
}