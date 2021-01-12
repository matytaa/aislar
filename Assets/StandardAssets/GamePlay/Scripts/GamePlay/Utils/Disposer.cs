using System;
using System.Collections.Generic;

namespace StandardAssets.GamePlay.Scripts.GamePlay.Utils
{
    public class Disposer : IDisposable
    {
        List<IDisposable> disposables = new List<IDisposable>();

        public static Disposer Create()
        {
            return new Disposer();
        }

        public Disposer Add(IDisposable disposable)
        {
            disposables.Add(disposable);
            return this;
        }

        public void Dispose()
        {
            foreach (var disposable in disposables)
            {
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            disposables.Clear();
        }
    }
}
