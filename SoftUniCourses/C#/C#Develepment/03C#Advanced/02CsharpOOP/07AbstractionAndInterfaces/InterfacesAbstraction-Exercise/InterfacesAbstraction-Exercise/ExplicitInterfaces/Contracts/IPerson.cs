﻿namespace ExplicitInterfaces.Contracts
{
    public interface IPerson
    {
        string Name { get; }
        int  Age { get; }
        string GetName();
    }
}