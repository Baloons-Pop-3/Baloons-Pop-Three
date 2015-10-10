//-----------------------------------------------------------------------
// <copyright file="IModel.cs" company="Baloons-Pop-Three">
//    Copyright Baloons-Pop-Three. All rights reserved
// </copyright>
// <summary>This is the IModel interface.</summary>
//-----------------------------------------------------------------------
namespace BalloonsPop.Models.Contracts
{
    /// <summary>
    /// Interface that provides property for getting and setting the id of a model.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Gets or sets the id of the model.
        /// </summary>
        /// <value>The id of the model.</value>
        string Id { get; set; }
    }
}