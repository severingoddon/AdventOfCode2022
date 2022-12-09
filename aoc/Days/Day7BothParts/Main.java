package org.example;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.*;


public class Main {
    private static Tree tree = new Tree();
    private static TreeNode currentNode;
    private static int fileCount = 0;

    public static void main(String[] args) {
        currentNode = new TreeNode("/");
        currentNode.setType(FileType.DIRECTORY);
        buildTree();
        currentNode = tree.getNode("/", null);
        addSizes(currentNode);
        findDirectoriesSmallerThan100k();
        System.out.println("directories with a total size of at most 100000: "+fileCount);
        //print the tree
        //System.out.println(toString("/",currentNode.getChildren()));

        //part two
        int remainingSize = 70000000-currentNode.getSize();
        int sizeToFreeUp = 30000000-remainingSize;

        TreeNode smallestDirectory = currentNode;
        for (TreeNode n : tree.getNodes()) {
            if(n.getSize()>=sizeToFreeUp && n.getSize() < smallestDirectory.getSize()){
                smallestDirectory = n;
            }
        }
        System.out.println("Size of smallest directory to delete is: "+smallestDirectory.getSize());
    }

    public static void buildTree(){
        tree.addNode(currentNode);
        try {
            Scanner scanner = new Scanner(new File("/Users/sevi/Desktop/Docs/IntelliJProjects/aoc/AOC/src/main/java/org/example/input.txt"));
            while (scanner.hasNextLine()) {
                handleLine(scanner.nextLine());
            }
            scanner.close();
        } catch (FileNotFoundException e) {e.printStackTrace();}
    }

    private static void handleLine(String line){
        String[] splitted = line.split(" ");
        if(splitted[0].equals("$")){
            if(splitted[1].equals("cd")){
                if(splitted[2].equals("..")){
                    currentNode = currentNode.getParent();
                }else{
                    if(tree.containsNode(splitted[2],FileType.DIRECTORY, currentNode)){
                        currentNode = tree.getNode(splitted[2], currentNode);
                    }else{
                        TreeNode newNode = new TreeNode(splitted[2]);
                        newNode.setType(FileType.DIRECTORY);
                        newNode.setParent(currentNode);
                        currentNode.addChild(newNode);
                        currentNode = newNode;
                        tree.addNode(newNode);
                    }
                }
            }
        }else{
            if(splitted[0].equals("dir")){
                if(!tree.containsNode(splitted[1],FileType.DIRECTORY, currentNode)){
                    TreeNode newNode = new TreeNode(splitted[1]);
                    newNode.setType(FileType.DIRECTORY);
                    newNode.setParent(currentNode);
                    currentNode.addChild(newNode);
                    tree.addNode(newNode);
                }
            }else{
                TreeNode newNode = new TreeNode(line);
                newNode.setType(FileType.FILE);
                newNode.setParent(currentNode);
                currentNode.addFile(Integer.parseInt(splitted[0]));
                currentNode.addChild(newNode);
                tree.addNode(newNode);
            }
        }
    }

    public static void addSizes(TreeNode child){ // post order traversal
        for(TreeNode each : child.getChildren()){
            addSizes(each);
        }
        if(child.getParent() != null){
            child.getParent().addFile(child.getSize());
        }
    }

    public static void findDirectoriesSmallerThan100k(){
        ArrayList<TreeNode> nodes = tree.getNodes();
        for (TreeNode n : nodes) {
            if(n.getType() == FileType.DIRECTORY){
                if(n.getSize()<=100000){
                    fileCount += n.getSize();
                }
            }
        }
    }

    //--------------------------print tree----------------------------

    public static String toString(String name, ArrayList<TreeNode> children) {
        StringBuilder buffer = new StringBuilder(50);
        print(buffer,"","",name,children);
        return buffer.toString();
    }

    private static void print(StringBuilder buffer, String prefix, String childrenPrefix, String name, ArrayList<TreeNode> children) {
        buffer.append(prefix);
        buffer.append(name);
        buffer.append('\n');
        for (Iterator<TreeNode> it = children.iterator(); it.hasNext();) {
            TreeNode next = it.next();
            if (it.hasNext()) {
                print(buffer, childrenPrefix + "├── ", childrenPrefix + "│   ",next.getName(),next.getChildren());
            } else {
                print(buffer, childrenPrefix + "└── ", childrenPrefix + "    ", next.getName(), next.getChildren());
            }
        }
    }
}