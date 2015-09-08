using System.IO;
using System.Text;
using NUnit.Framework;

namespace KattisSolution.Tests
{
    [TestFixture]
    [Category("sample")]
    public class CustomTest
    {
        [Ignore]
        [Test]
        public void SampleTest_WithStringData_Should_Pass()
        {
            // Arrange
            const string expectedAnswer = "50\n";
            using (var input = new MemoryStream(Encoding.UTF8.GetBytes("10\n")))
            using (var output = new MemoryStream())
            {
                // Act
                Program.Solve(input, output);
                var result = Encoding.UTF8.GetString(output.ToArray());

                // Assert
                Assert.That(result, Is.EqualTo(expectedAnswer));
            }
        }

        [Test]
        public void CalculateDistance()
        {
            //-612 -649
            //619 898
            //919 948
            //-847 -224
            //-112 -672
            //819 658
            //-42 -858
            //-287 661
            //799 1
            //-696 249

            // Arrange
            Point a = new Point(918, 948);
        }
    }
}
