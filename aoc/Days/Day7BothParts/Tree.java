package org.example;

import java.util.ArrayList;

public class Tree {

    private ArrayList<TreeNode> nodes = new ArrayList<>();

    public ArrayList<TreeNode> getNodes(){
        return nodes;
    }

    public TreeNode getNode(String name, TreeNode parentNode){
        if(parentNode == null || nodes.size()==1){
            for (TreeNode n : nodes) {
                if(name.equals(n.getName())){
                    return n;
                }
            }
        }
        for (TreeNode n : nodes) {
            if(name.equals(n.getName()) && n.getParent().equals(parentNode)){
                return n;
            }
        }
        return null;
    }

    public void addNode(TreeNode node){
        nodes.add(node);
    }

    public boolean containsNode(String node, FileType t, TreeNode parentNode){
        if(parentNode==null || nodes.size() == 1){
            for (TreeNode n : nodes) {
                if(node.equals(n.getName()) && n.getType()==t){
                    return true;
                }
            }
        }
        for (TreeNode n : nodes) {
            if(node.equals(n.getName()) && n.getType()==t && n.getParent().equals(parentNode)){
                return true;
            }
        }
        return false ;
    }
}
