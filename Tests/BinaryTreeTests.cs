using BinaryTree;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class BinaryTreeTests
    {
        [Fact]
        public void EmptyBST_InsertOneElement_ShouldInsertRoot()
        {
            // Arrange
            int numberToInsert = 10;
            BinaryTree<int> tree = new BinaryTree<int>();
            // Act
            tree.Insert(numberToInsert);

            // Assert
            Assert.NotNull(tree.Root);
            Assert.Equal(numberToInsert, tree.Root.Data);
        }

        [Fact]
        public void NotEmptyBST_InsertOneElement_ShouldContainsIt()
        {
            // Arrange
            int numberToInsert = 10;
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.InsertRange(new int[] { 5, 3 });
            // Act
            tree.Insert(numberToInsert);

            // Assert
            Assert.NotNull(tree.Root);
            Assert.NotNull(tree.Find(numberToInsert));
        }

        [Fact]
        public void BST_InsertNullValue_ShouldThrowArgumentNullException()
        {
            string valueToInsert = null;
            BinaryTree<string> tree = new BinaryTree<string>();
            
            Assert.Throws<ArgumentNullException>(() => tree.Insert(valueToInsert));        
        }

        [Fact]
        public void EmptyBST_InsertSeveralElements_ShouldInsertTheseElements()
        {
            // Arrange
            int[] numbersToInsert = { 1, 2, 3, 4};
            BinaryTree<int> tree = new BinaryTree<int>();
            // Act
            tree.InsertRange(numbersToInsert);

            // Assert
            Assert.NotNull(tree.Root);
            foreach(int number in numbersToInsert)
            {
                Assert.Equal(tree.Find(number).Data, number);
            }
            
        }
        [Fact]
        public void BST_FindExistingElement_BSTNodeShouldIcludeIt()
        {
            // Arrange
            int numberToFind = 10;
            BinaryTree<int> tree = new BinaryTree<int>();
            int[] numbersToInsert = { 10, 2, 3, 4 };
            tree.InsertRange(numbersToInsert);
            // Act
            var node = tree.Find(numberToFind);

            // Assert
            
            Assert.Equal(numberToFind, node.Data);
        }

        [Fact]
        public void BST_FindNotExistingElement_ShouldReturnNullNode()
        {
            // Arrange
            int numberToFind = 10;
            BinaryTree<int> tree = new BinaryTree<int>();
            int[] numbersToInsert = { 1, 2, 3, 4 };
            tree.InsertRange(numbersToInsert);
            // Act
            var node = tree.Find(numberToFind);

            // Assert

            Assert.Null(node);
        }

        [Fact]
        public void BST_TryToFindNullValue_ShouldThrowArgumentNullException()
        {
            string valueToFind = null;
            BinaryTree<string> tree = new BinaryTree<string>();

            Assert.Throws<ArgumentNullException>(() => tree.Find(valueToFind));
        }

        [Fact]
        public void Test_ThatMyEventIsRaised()
        {
            List<string> receivedEvents = new List<string>();
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Notify += delegate (int data, string message)
            {
                 receivedEvents.Add(message);
            };

            tree.Insert(2);
            tree.Insert(5);
            Assert.Equal(2, receivedEvents.Count);
            Assert.Equal("Was added node with value: 2", receivedEvents[0]);
            Assert.Equal("Was added node with value: 5", receivedEvents[1]);
            
        }

        [Fact]
        public void BST_RemoveExistingElement_ThisRootShouldBeNull()
        {
            // Arrange
            int number = 10;
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Insert(number);
            
            // Act
            tree.Remove(number);

            // Assert
            Assert.Null(tree.Root);
            Assert.Null(tree.Find(number));
        }

        [Fact]
        public void BST_RemoveNotExistingElement_ReturnRoot()
        {
            // Arrange
            int number = 10;
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Insert(1);

            // Act
            tree.Remove(number);

            // Assert
            Assert.NotNull(tree.Root);
            Assert.Null(tree.Find(number));
        }

        [Fact]
        public void BST_TryToRemoveNullValue_ShouldThrowArgumentNullException()
        {
            string valueToRemove = null;
            BinaryTree<string> tree = new BinaryTree<string>();

            Assert.Throws<ArgumentNullException>(() => tree.Remove(valueToRemove));
        }

        [Fact]
        public void BST_PreOrder3145_ShouldReturn3145()
        {
            // Arrange
            
            BinaryTree<int> tree = new BinaryTree<int>();
            int[] numbersToInsert = { 3, 1, 4, 5 };
            tree.InsertRange(numbersToInsert);
            int[] expected = { 3, 1, 4, 5 };
            // Act
            var result = tree.PreOrder(tree.Root);

            // Assert

            Assert.Equal(expected, result);
        }
    }
}
