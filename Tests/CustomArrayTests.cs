using Array;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class CustomArrayTests
    {
        [Fact]
        public void EmptyArray_AddElement_HasThisElement ()
        {
            // Arrange
            CustomArray<int> list = new CustomArray<int>(0, 1);
            int insert = 10;
            // Act
            list.Add(insert);

            // Assert
            Assert.NotNull(list);
            Assert.Equal(insert, list.FindNode(insert).Data);
        }

        [Fact]
        public void Array_TryInsertElementByInvalidIndex_ThrowIndexOutOfRangeException()
        {
            //Arrange
            string valueToInsert = null;
            CustomArray<string> list = new CustomArray<string>(0, 1);

            //Act
            Assert.Throws<IndexOutOfRangeException>(() => list.InsertByIndex(valueToInsert, 6));
        }

        [Fact]
        public void EmptyArray_InsertElementByIndex_HasThisElementByThisIndex()
        {
            // Arrange
            CustomArray<int> list = new CustomArray<int>(0, 0);
            int insert0 = 10;
            
            // Act
            list.InsertByIndex(insert0, 0);
            
            // Assert
            Assert.NotNull(list);
            Assert.Equal(insert0, list[0]);
        }

        [Fact]
        public void EmptyArray_PushFrontElement_HasThisElementInFirstPosition()
        {
            // Arrange
            CustomArray<int> list = new CustomArray<int>(0, 0);
            int insert0 = 10;

            // Act
            list.PushFront(insert0);

            // Assert
            Assert.NotNull(list);
            Assert.Equal(insert0, list[0]);
        }

        [Fact]
        public void EmptyArray_PopFrontElement_NotHasThisElement()
        {
            // Arrange
            CustomArray<int> list = new CustomArray<int>(0, 1);
            int insert0 = 10;
            int insert1 = 11;
            list.PushFront(insert0);
            list.Add(insert1);
            // Act
            list.PopFront();

            // Assert
            Assert.Null(list.FindNode(insert0));
        }

        [Fact]
        public void Array_TryPopFrontFromEmptyArray_ThrowEmptyArrayException()
        {
            //Arrange
            
            CustomArray<string> list = new CustomArray<string>(0, 0);
            list.First = null;
            //Act
            Assert.Throws<EmptyArrayException>(() => list.PopFront());
        }

        [Fact]
        public void EmptyArray_PopBackElement_NotHasThisElementInLastPosition()
        {
            // Arrange
            CustomArray<int> list = new CustomArray<int>(0, 1);
            int insert0 = 10;
            int insert1 = 11;
            list.PushFront(insert0);
            list.Add(insert1);
            // Act
            list.PopBack();

            // Assert
            Assert.Null(list.FindNode(insert1));
        }

        [Fact]
        public void Array_TryPopBackFromEmptyArray_ThrowEmptyArrayException()
        {
            //Arrange

            CustomArray<string> list = new CustomArray<string>(0, 0);
            list.Last = null;
            //Act
            Assert.Throws<EmptyArrayException>(() => list.PopBack());
        }

        [Fact]
        public void NotEmptyArray_PerformClearList_ShouldReturnEmptyArray()
        {
            // Arrange
            CustomArray<int> list = new CustomArray<int>(0, 1);
            int insert0 = 10;
            int insert1 = 11;
            list.PushFront(insert0);
            list.Add(insert1);
            // Act
            list.ClearList();

            // Assert
            Assert.Empty(list);
        }

        [Fact]
        public void CustomArray_Traverse3145_ShouldReturn3145()
        {
            // Arrange

            CustomArray<int> list = new CustomArray<int>(0, 3)
            { [0] = 3,
              [1] = 1,
              [2] = 4,
              [3] = 5
            };

            int[] expected = { 3, 1, 4, 5 };
            // Act
            var result = list.Traverse();

            // Assert

            Assert.Equal(expected, result);
        }
        [Fact]
        public void CustomArray_RemoveExistingElement_ThisElementShouldBeDeleted()
        {
            // Arrange
            int number = 10;
            CustomArray<int> list = new CustomArray<int>(0, 3)
            {
                [0] = 10,
                [1] = 1,
                [2] = 4,
                [3] = 5
            };
            // Act
            var result = list.Remove(number);

            // Assert
            Assert.True(result);
            Assert.Null(list.FindNode(10));
        }

        [Fact]
        public void CustomArray_TryToRemoveNullValue_ShouldThrowArgumentNullException()
        {
            string valueToRemove = null;

            CustomArray<string> list = new CustomArray<string>(0, 3)
            {
                [0] = "A",
                [1] = "B",
                [2] = "C",
                [3] = "D"
            };

            Assert.Throws<ArgumentNullException>(() => list.Remove(valueToRemove));
        }
    }
}
