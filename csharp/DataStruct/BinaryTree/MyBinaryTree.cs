using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStruct.BinaryTree
{
    public class MyBinaryTree<T>
    {
        public MyBinaryTree(T var)
        {
            if (var != null)
            {
                this.root = new Node<T>(var);
            }
        }

        private Node<T> root;

        public Node<T> Root { get { return root; } private set { root = value; } }

        // Method01:判断该二叉树是否是空树
        public bool IsEmpty()
        {
            return this.root == null;
        }

        // Method02:在节点p下插入左孩子节点的data
        public void InsertLeft(Node<T> p, T data)
        {
            Node<T> tempNode = new Node<T>(data);
            tempNode.lchild = p.lchild;

            p.lchild = tempNode;
        }

        // Method03:在节点p下插入右孩子节点的data
        public void InsertRight(Node<T> p, T data)
        {
            Node<T> tempNode = new Node<T>(data);
            tempNode.rchild = p.rchild;

            p.rchild = tempNode;
        }

        // Method04:删除节点p下的左子树
        public Node<T> RemoveLeft(Node<T> p)
        {
            if (p == null || p.lchild == null)
            {
                return null;
            }

            Node<T> tempNode = p.lchild;
            p.lchild = null;
            return tempNode;
        }

        // Method05:删除节点p下的右子树
        public Node<T> RemoveRight(Node<T> p)
        {
            if (p == null || p.rchild == null)
            {
                return null;
            }

            Node<T> tempNode = p.rchild;
            p.rchild = null;
            return tempNode;
        }


        // Method01:前序遍历
        public void PreOrder(Node<T> node)
        {
            if (node != null)
            {
                // 根->左->右
                Console.Write(node.data + " ");
                PreOrder(node.lchild);
                PreOrder(node.rchild);
            }
        }

        // Method02:中序遍历
        public void MidOrder(Node<T> node)
        {
            if (node != null)
            {
                // 左->根->右
                MidOrder(node.lchild);
                Console.Write(node.data + " ");
                MidOrder(node.rchild);
            }
        }

        // Method03:后序遍历
        public void PostOrder(Node<T> node)
        {
            if (node != null)
            {
                // 左->右->根
                PostOrder(node.lchild);
                PostOrder(node.rchild);
                Console.Write(node.data + " ");
            }
        }

        // Method01:前序遍历
        public void PreOrderNoRecurise(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            // 根->左->右
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(node);
            Node<T> tempNode = null;

            while (stack.Count > 0)
            {
                // 1.遍历根节点
                tempNode = stack.Pop();
                Console.Write(tempNode.data);
                // 2.右子树压栈
                if (tempNode.rchild != null)
                {
                    stack.Push(tempNode.rchild);
                }
                // 3.左子树压栈(目的：保证下一个出栈的是左子树的节点)
                if (tempNode.lchild != null)
                {
                    stack.Push(tempNode.lchild);
                }
            }
        }

        public void MidOrderNoRecurise(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            // 左->根->右
            Stack<Node<T>> stack = new Stack<Node<T>>();
            Node<T> tempNode = node;

            while (tempNode != null || stack.Count > 0)
            {
                // 1.依次将所有左子树节点压栈
                while (tempNode != null)
                {
                    stack.Push(tempNode);
                    tempNode = tempNode.lchild;
                }
                // 2.出栈遍历节点
                tempNode = stack.Pop();
                Console.Write(tempNode.data);
                // 3.左子树遍历结束则跳转到右子树
                tempNode = tempNode.rchild;
            }
        }
    }

    /// <summary>
    /// 二叉树的节点定义
    /// </summary>
    /// <typeparam name="T">数据具体类型</typeparam>
    public class Node<T>
    {
        public T data { get; set; }

        public Node<T> lchild { get; set; }

        public Node<T> rchild { get; set; }

        public Node()
        {
        }

        public Node(T data)
        {
            this.data = data;
        }

        public Node(T data, Node<T> lchild, Node<T> rchild)
        {
            this.data = data;
            this.lchild = lchild;
            this.rchild = rchild;
        }
    }
}