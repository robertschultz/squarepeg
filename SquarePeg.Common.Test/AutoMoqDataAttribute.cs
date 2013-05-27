namespace SquarePeg.Common.Test
{
    using System.Diagnostics.CodeAnalysis;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoMoq;
    using Ploeh.AutoFixture.Xunit;

    /// <summary>
    /// Attribute used to wire up AutoFixture for Moq creation.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMoqDataAttribute"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor overload initializes the <see cref="P:Ploeh.AutoFixture.Xunit.AutoDataAttribute.Fixture" /> to an instance of
        /// <see cref="P:Ploeh.AutoFixture.Xunit.AutoDataAttribute.Fixture" />.
        /// </remarks>
        public AutoMoqDataAttribute()
            : base(new Fixture()
                .Customize(new AutoMoqCustomization()))
        {
        }
    }
}
