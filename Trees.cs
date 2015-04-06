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
        public treeNode getLeft()  { return left;  }
        public treeNode getRight() { return right; }
        public int getData()       { return data;  }

        //setter
        public void setData(int ndata)   { data = ndata; }
        public void setRight(treeNode r) { right = r;    }
        public void setLeft(treeNode l)  { left = l;     }

        public treeNode(int ndata) { data = ndata; }

        public void add(int ndata)
        {
            if (ndata == this.data) return;                                 //glitch protection

            else if (ndata < this.data)                                 
                if (this.left == null) left = new treeNode(ndata);          //new left child
                else left.add(ndata);                                       //move pointer to left child

            else if (ndata > this.data)
                if (this.right == null) right = new treeNode(ndata);        //new right child
                else right.add(ndata);                                      //move pointer to right child
        }

        public string ToString(string outStr)
        {
            outStr += this.getData() + " ";                                 //add current node's data to the pintout
            if (this.left != null)  outStr = this.left.ToString(outStr);    //move to the left child if it exists
            if (this.right != null) outStr = this.right.ToString(outStr);   //move to the right child if it exists
            return outStr;
        }
    }

    class BinarySearchTree
    {
        treeNode root;

        //construct a BST via integer data array
       public BinarySearchTree(int [] dataArray) { root = buildTree(dataArray); }

        treeNode buildTree(int [] dataArray)
       {
           int current = 0;
           while (current <= dataArray.Length - 1)
           {
               addNode(dataArray[current]);
               current++;
           }
           return root;
       }

        void addNode(int data)
        {
            if (root == null) root = new treeNode(data);
            else root.add(data);
        }

        void readdSubtree(treeNode n)
        {
            addNode(n.getData());
            if (n.getLeft() != null) readdSubtree(n.getLeft());
            if (n.getRight() != null) readdSubtree(n.getRight());
        }

        public void deleteNode(int ndata) { delete(root, null, ndata); }

        void delete(treeNode n, treeNode parent, int ndata)
        {
            if(n.getData() == ndata)
            {
                //return if we are the parent. can't delete anything if we're the root right now.
                if (parent == null) return;

                if (n.getLeft() != null && n.getRight() != null)
                {
                    treeNode subRoot = n;                                               //create new subtree
                    if (parent.getLeft() == n) parent.setLeft(null);                    //detach from parent if we're to its left
                    else if (parent.getRight() == n) parent.setRight(null);             //detach from parent if we're to its right

                    readdSubtree(subRoot.getLeft());                                    //readd the left subtree into the main tree
                    readdSubtree(subRoot.getRight());                                   //readd the right subtree into the main tree
                }

                //eliminate rework by handling trivial cases seperately
                else if (n.getLeft() != null)
                    if (parent.getLeft() == n) parent.setLeft(n.getLeft());
                    else if (parent.getRight() == n) parent.setLeft(n.getLeft());

                else if (n.getRight() != null)

                    if (parent.getLeft() == n) parent.setLeft(n.getRight());            
                    else if (parent.getRight() == n) parent.setLeft(n.getRight());      

                else

                    if (parent.getLeft() == n) parent.setLeft(null);                    //delink left
                    else if (parent.getRight() == n) parent.setRight(null);             //delink right

            }
            else
                if (n.getLeft() != null)  delete(n.getLeft() , n, ndata);               //search left child for target
                if (n.getRight() != null) delete(n.getRight(), n, ndata);               //search right child for target
        }

        //print the binary tree
        public override string ToString() { return root.ToString(""); }                 //instruct root to print itself and all children
    }
}
