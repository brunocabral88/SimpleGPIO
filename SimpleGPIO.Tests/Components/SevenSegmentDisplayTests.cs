using System.Collections;
using System.Collections.Generic;
using SimpleGPIO.Components;
using SimpleGPIO.Power;
using SimpleGPIO.Tests.GPIO;
using Xunit;

namespace SimpleGPIO.Tests.Components
{
    public class SevenSegmentDisplayTests
    {
        [Theory, ClassData(typeof(CharacterData))]
        public void TestCharacters(char character, string expected)
        {
            //arrange
            var center = new StubPinInterface(1);
            var upperLeft = new StubPinInterface(2);
            var top = new StubPinInterface(3);
            var upperRight = new StubPinInterface(4);
            var lowerLeft = new StubPinInterface(5);
            var bottom = new StubPinInterface(6);
            var lowerRight = new StubPinInterface(7);
            var decimalPoint = new StubPinInterface(8);
            var display = new SevenSegmentDisplay(center, upperLeft, top, upperRight, lowerLeft, bottom, lowerRight, decimalPoint);

            //act
            display.Show(character);

            //assert
            Assert.Equal(expected[1] == '*' ? PowerValue.On : PowerValue.Off, top.Power);
            Assert.Equal(expected[3] == '*' ? PowerValue.On : PowerValue.Off, upperLeft.Power);
            Assert.Equal(expected[5] == '*' ? PowerValue.On : PowerValue.Off, upperRight.Power);
            Assert.Equal(expected[7] == '*' ? PowerValue.On : PowerValue.Off, center.Power);
            Assert.Equal(expected[9] == '*' ? PowerValue.On : PowerValue.Off, lowerLeft.Power);
            Assert.Equal(expected[11] == '*' ? PowerValue.On : PowerValue.Off, lowerRight.Power);
            Assert.Equal(expected[13] == '*' ? PowerValue.On : PowerValue.Off, bottom.Power);
            
            if(expected.Length > 15)
                Assert.Equal(expected[15] == '*' ? PowerValue.On : PowerValue.Off, decimalPoint.Power);
        }
    }

    public class CharacterData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                ' ', "   " +
                     "   " +
                     "   " +
                     "   " +
                     "   "
            };

            yield return new object[]
            {
                '"', "   " +
                     "* *" +
                     "   " +
                     "   " +
                     "   "
            };

            yield return new object[]
            {
                '\'',"   " +
                     "  *" +
                     "   " +
                     "   " +
                     "   "
            };

            yield return new object[]
            {
                '(', " * " +
                     "*  " +
                     "   " +
                     "*  " +
                     " * "
            };

            yield return new object[]
            {
                ')', " * " +
                     "  *" +
                     "   " +
                     "  *" +
                     " * "
            };

            yield return new object[]
            {
                ',', "   " +
                     "   " +
                     "   " +
                     "  *" +
                     "   "
            };

            yield return new object[]
            {
                '-', "   " +
                     "   " +
                     " * " +
                     "   " +
                     "   "
            };

            yield return new object[]
            {
                '.', "   " +
                     "   " +
                     "   " +
                     "   " +
                     "   *"
            };

            yield return new object[]
            {
                '/', "   " +
                     "  *" +
                     " * " +
                     "*  " +
                     "   "
            };

            yield return new object[]
            {
                '0', " * " +
                     "* *" +
                     "   " +
                     "* *" +
                     " * "
            };

            yield return new object[]
            {
                '1', "   " +
                     "  *" +
                     "   " +
                     "  *" +
                     "   "
            };

            yield return new object[]
            {
                '2', " * " +
                     "  *" +
                     " * " +
                     "*  " +
                     " * "
            };

            yield return new object[]
            {
                '3', " * " +
                     "  *" +
                     " * " +
                     "  *" +
                     " * "
            };

            yield return new object[]
            {
                '4', "   " +
                     "* *" +
                     " * " +
                     "  *" +
                     "   "
            };

            yield return new object[]
            {
                '5', " * " +
                     "*  " +
                     " * " +
                     "  *" +
                     " * "
            };

            yield return new object[]
            {
                '6', " * " +
                     "*  " +
                     " * " +
                     "* *" +
                     " * "
            };

            yield return new object[]
            {
                '7', " * " +
                     "  *" +
                     "   " +
                     "  *" +
                     "   "
            };

            yield return new object[]
            {
                '8', " * " +
                     "* *" +
                     " * " +
                     "* *" +
                     " * "
            };

            yield return new object[]
            {
                '9', " * " +
                     "* *" +
                     " * " +
                     "  *" +
                     " * "
            };

            yield return new object[]
            {
                '<', "   " +
                     "   " +
                     " * " +
                     "*  " +
                     " * "
            };

            yield return new object[]
            {
                '=', "   " +
                     "   " +
                     " * " +
                     "   " +
                     " * "
            };

            yield return new object[]
            {
                '>', "   " +
                     "   " +
                     " * " +
                     "  *" +
                     " * "
            };
            
            yield return new object[]
            {
                'A', " * " +
                     "* *" +
                     " * " +
                     "* *" +
                     "   "
            };
            
            yield return new object[]
            {
                'B', " * " +
                     "* *" +
                     " * " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'C', " * " +
                     "*  " +
                     "   " +
                     "*  " +
                     " * "
            };
            
            yield return new object[]
            {
                'D', " * " +
                     "* *" +
                     "   " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'E', " * " +
                     "*  " +
                     " * " +
                     "*  " +
                     " * "
            };
            
            yield return new object[]
            {
                'F', " * " +
                     "*  " +
                     " * " +
                     "*  " +
                     "   "
            };
            
            yield return new object[]
            {
                'G', " * " +
                     "*  " +
                     "   " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'H', "   " +
                     "* *" +
                     " * " +
                     "* *" +
                     "   "
            };
            
            yield return new object[]
            {
                'I', "   " +
                     "*  " +
                     "   " +
                     "*  " +
                     "   "
            };
            
            yield return new object[]
            {
                'J', "   " +
                     "  *" +
                     "   " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'K', "   " +
                     "* *" +
                     " * " +
                     "* *" +
                     "   "
            };
            
            yield return new object[]
            {
                'L', "   " +
                     "*  " +
                     "   " +
                     "*  " +
                     " * "
            };
            
            yield return new object[]
            {
                'M', " * " +
                     "* *" +
                     "   " +
                     "* *" +
                     "   "
            };
            
            yield return new object[]
            {
                'N', "   " +
                     "* *" +
                     " * " +
                     "* *" +
                     "   "
            };
            
            yield return new object[]
            {
                'O', " * " +
                     "* *" +
                     "   " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'P', " * " +
                     "* *" +
                     " * " +
                     "*  " +
                     "   "
            };
            
            yield return new object[]
            {
                'Q', " * " +
                     "* *" +
                     "   " +
                     "* *" +
                     " * *"
            };
            
            yield return new object[]
            {
                'R', " * " +
                     "* *" +
                     " * " +
                     "* *" +
                     "   "
            };
            
            yield return new object[]
            {
                'S', " * " +
                     "*  " +
                     " * " +
                     "  *" +
                     " * "
            };
            
            yield return new object[]
            {
                'T', " * " +
                     "*  " +
                     "   " +
                     "*  " +
                     "   "
            };
            
            yield return new object[]
            {
                'U', "   " +
                     "* *" +
                     "   " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'V', "   " +
                     "* *" +
                     " * " +
                     "*  " +
                     "   "
            };
            
            yield return new object[]
            {
                'W', "   " +
                     "* *" +
                     "   " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'X', "   " +
                     "* *" +
                     " * " +
                     "* *" +
                     "   "
            };
            
            yield return new object[]
            {
                'Y', "   " +
                     "* *" +
                     " * " +
                     "  *" +
                     "   "
            };
            
            yield return new object[]
            {
                'Z', " * " +
                     "  *" +
                     " * " +
                     "*  " +
                     " * "
            };
            
            yield return new object[]
            {
                '[', " * " +
                     "*  " +
                     "   " +
                     "*  " +
                     " * "
            };
            
            yield return new object[]
            {
                '\\',"   " +
                     "*  " +
                     " * " +
                     "  *" +
                     "   "
            };
            
            yield return new object[]
            {
                ']', " * " +
                     "  *" +
                     "   " +
                     "  *" +
                     " * "
            };

            yield return new object[]
            {
                '^', " * " +
                     "* *" +
                     "   " +
                     "   " +
                     "   "
            };

            yield return new object[]
            {
                '_', "   " +
                     "   " +
                     "   " +
                     "   " +
                     " * "
            };

            yield return new object[]
            {
                '`', "   " +
                     "*  " +
                     "   " +
                     "   " +
                     "   "
            };

            yield return new object[]
            {
                'a', " * " +
                     "  *" +
                     " * " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'b', "   " +
                     "*  " +
                     " * " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'c', "   " +
                     "   " +
                     " * " +
                     "*  " +
                     " * "
            };
            
            yield return new object[]
            {
                'd', "   " +
                     "  *" +
                     " * " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'e', " * " +
                     "* *" +
                     " * " +
                     "*  " +
                     " * "
            };
            
            yield return new object[]
            {
                'f', " * " +
                     "*  " +
                     " * " +
                     "*  " +
                     "   "
            };
            
            yield return new object[]
            {
                'g', " * " +
                     "* *" +
                     " * " +
                     "  *" +
                     " * "
            };
            
            yield return new object[]
            {
                'h', "   " +
                     "*  " +
                     " * " +
                     "* *" +
                     "   "
            };
            
            yield return new object[]
            {
                'i', "   " +
                     "   " +
                     "   " +
                     "*  " +
                     "   "
            };
            
            yield return new object[]
            {
                'j', "   " +
                     "   " +
                     "   " +
                     "  *" +
                     " * "
            };
            
            yield return new object[]
            {
                'k', "   " +
                     "*  " +
                     " * " +
                     "* *" +
                     "   "
            };
            
            yield return new object[]
            {
                'l', "   " +
                     "*  " +
                     "   " +
                     "*  " +
                     "   "
            };
            
            yield return new object[]
            {
                'm', "   " +
                     "   " +
                     " * " +
                     "* *" +
                     "   "
            };
            
            yield return new object[]
            {
                'n', "   " +
                     "   " +
                     " * " +
                     "* *" +
                     "   "
            };
            
            yield return new object[]
            {
                'o', "   " +
                     "   " +
                     " * " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'p', " * " +
                     "* *" +
                     " * " +
                     "*  " +
                     "   "
            };
            
            yield return new object[]
            {
                'q', " * " +
                     "* *" +
                     " * " +
                     "  *" +
                     "   "
            };
            
            yield return new object[]
            {
                'r', "   " +
                     "   " +
                     " * " +
                     "*  " +
                     "   "
            };
            
            yield return new object[]
            {
                's', " * " +
                     "*  " +
                     " * " +
                     "  *" +
                     " * "
            };
            
            yield return new object[]
            {
                't', "   " +
                     "*  " +
                     " * " +
                     "*  " +
                     " * "
            };
            
            yield return new object[]
            {
                'u', "   " +
                     "   " +
                     "   " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'v', "   " +
                     "   " +
                     "   " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'w', "   " +
                     "   " +
                     "   " +
                     "* *" +
                     " * "
            };
            
            yield return new object[]
            {
                'x', "   " +
                     "* *" +
                     " * " +
                     "* *" +
                     "   "
            };
            
            yield return new object[]
            {
                'y', "   " +
                     "* *" +
                     " * " +
                     "  *" +
                     "   "
            };
            
            yield return new object[]
            {
                'z', " * " +
                     "  *" +
                     " * " +
                     "*  " +
                     " * "
            };
            
            yield return new object[]
            {
                '{', " * " +
                     "*  " +
                     "   " +
                     "*  " +
                     " * "
            };
            
            yield return new object[]
            {
                '|', "   " +
                     "*  " +
                     "   " +
                     "*  " +
                     "   "
            };
            
            yield return new object[]
            {
                '}', " * " +
                     "  *" +
                     "   " +
                     "  *" +
                     " * "
            };
            
            yield return new object[]
            {
                '~', " * " +
                     "   " +
                     "   " +
                     "   " +
                     "   "
            };
        }
    }
}
