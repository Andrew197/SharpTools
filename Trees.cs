using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharptools.Trees
{
    //tree structure data node
    class treeNode
    {
        int data;
        treeNode left;
        treeNode right;

        //getters
        public treeNode getLeft() { return left; }
        public treeNode getRight() { return right; }
        public int getData() { return data; }

        //setter
        public void setData(int ndata) { data = ndata; }
        public treeNode(int ndata) { data = ndata; }

        public void add(int ndata)
        {
            if (ndata == this.data) return;
            else if (ndata < this.data)
            {
                if (this.left == null) left = new treeNode(ndata);
                else left.add(ndata);
            }
            else if (ndata > this.data)
            {
                if (this.right == null) right = new treeNode(ndata);
                else right.add(ndata);
            }
        }

    }

    class BinarySearchTree
    {
        treeNode root;

        //construct a BST via integer data array
       public BinarySearchTree(int [] dataArray)
        {
            root = buildTree(dataArray);
        }

        treeNode buildTree(int [] dataArray)
       {
           Console.WriteLine("generating " + dataArray.Length + " treeNodes");
           int remaining = dataArray.Length - 1
               ;
           while (remaining >= 0)
           {
               addNode(dataArray[remaining]);
               remaining--;
           }
           return root;
       }

        void addNode(int data)
        {
          if (root == null) root = new treeNode(data);
          else root.add(data);
        }
    }
}
