﻿namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {


        public BinarySearchTree(Node<T> root = null)
        {
            this.Coppy(root);
        }

        private void Coppy(Node<T> root)
        {
            if (root != null)
            {
                this.Insert(root.Value);
                this.Coppy(root.LeftChild);
                this.Coppy(root.RightChild);
            }
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public bool Contains(T element)
        {
            throw new NotImplementedException();

        }

        public void Insert(T element)
        {
            throw new NotImplementedException();
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            throw new NotImplementedException();
        }
    }
}
