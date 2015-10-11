//-----------------------------------------------------------------------
// <copyright file="ISerializer.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the ISerializer interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Common.Serializer.Contracts
{
    /// <summary>
    /// Serializer interface.
    /// </summary>
    internal interface ISerializer
    {
        string Serialize<T>(T entity) where T : class;

        T Deserialize<T>(string input) where T : class;
    }
}