using System;

public interface IHandler
{
    void SetSuccessor(IHandler handler);

    void Handle(LogType tpe, string message);
}