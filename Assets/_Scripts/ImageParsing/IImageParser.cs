using System;
using System.Collections;

public interface IImageParser
{
    public IEnumerator ParseImage(Action<byte[]> callback);
}
