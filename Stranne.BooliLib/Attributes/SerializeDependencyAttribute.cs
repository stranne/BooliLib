using System;

namespace Stranne.BooliLib.Attributes
{
    internal class SerializeDependencyAttribute : Attribute
    {
        public string DependentUpon { get; private set; }

        public SerializeDependencyAttribute(string dependentUpon)
        {
            DependentUpon = dependentUpon;
        }
    }
}
