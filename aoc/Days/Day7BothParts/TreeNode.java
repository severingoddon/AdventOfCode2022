package org.example;

import java.util.ArrayList;

public class TreeNode {

    private String name;
    private FileType type = null;
    private TreeNode parent;
    private ArrayList<TreeNode> children = new ArrayList<>();
    private int size = 0;

    public String getName() {
        return name;
    }

    public int getSize(){
        return this.size;
    }

    public void setType(FileType t){
        this.type = t;
    }

    public FileType getType(){
        return this.type;
    }

    public void addFile(int size){
        this.size += size;
    }

    public void setName(String name) {
        this.name = name;
    }

    public TreeNode getParent() {
        if(parent == null){
            return null;
        }
        return parent;
    }

    public void setParent(TreeNode parent) {
        if(this.parent == null){
            this.parent = parent;
        }
    }

    public ArrayList<TreeNode> getChildren() {
        return children;
    }

    public void addChild(TreeNode node) {
        if(!children.contains(node)){
            children.add(node);
        }
    }

    public TreeNode(String name) {
        this.name = name;
    }
}
