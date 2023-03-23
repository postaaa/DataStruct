using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStruct.BinaryTree;

namespace DataStruct.BinaryTree
{
    public class MyBinaryTreeBasicTest
    {
        public static void Test()
        {
            // 构造一颗二叉树，根节点为"A"
            MyBinaryTree<string> bTree = new MyBinaryTree<string>("A");
            Node<string> rootNode = bTree.Root;
            // 向根节点"A"插入左孩子节点"B"和右孩子节点"C"
            bTree.InsertLeft(rootNode, "B");
            bTree.InsertRight(rootNode, "C");
            // 向节点"B"插入左孩子节点"D"和右孩子节点"E"
            Node<string> nodeB = rootNode.lchild;
            bTree.InsertLeft(nodeB, "D");
            bTree.InsertRight(nodeB, "E");
            // 向节点"C"插入右孩子节点"F"
            Node<string> nodeC = rootNode.rchild;
            bTree.InsertRight(nodeC, "F");

            // 前序遍历
            Console.WriteLine("---------PreOrder---------");
            //ree.PreOrder(bTree.Root);
            bTree.PreOrderNoRecurise(bTree.Root);
            // 中序遍历
            Console.WriteLine();
            Console.WriteLine("---------MidOrder---------");
            bTree.MidOrderNoRecurise(bTree.Root);
            // 后序遍历
            Console.WriteLine();
            Console.WriteLine("---------PostOrder---------");
            bTree.PostOrder(bTree.Root);
        }
    }
}