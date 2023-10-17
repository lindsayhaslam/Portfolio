//
//  main.cpp
//  BookAnalyzerHW
//
//  Created by Lindsay Haslam on 8/31/23.
//

#include <iostream>
#include <string>
#include <cstdlib>
#include <vector>
#include <fstream>
#include "BookAnalyzerFunctions.hpp"


int main(int argc, const char * argv[]) {
    //2591-0.txt Grimm's FairyTales
    
    //Initialized Variables
    std::vector<std::string> allWords;
    std::string userKeyword;
    std::string fileName;
    std::string word1;
    
    //Prompt the user for fileName and userKeyword
    std::cout << "Please enter a file you want to read: ";
    std::cin >> fileName;
    std::cout << "Now enter a keyword to search: ";
    std::cin >> userKeyword;
    
    //Read the file
    std::ifstream myStream(fileName);
    
    //Display fail message if file fails or is invalid
    if(myStream.fail() ) {
        std::cout << "Failed to file.\n";
        exit( 1 ); // Kill the program and exit with a return value of 1
    }
    
    //Create a vector with the entire text
    while(myStream >> word1) {
        allWords.push_back(word1);
    }
    
   //All functions in action
   TitleOfBook(allWords);
   AuthorOfBook(allWords);
   NumberOfWords(allWords);
   NumberOfCharacters(myStream);
   ShortestWordInBook(allWords);
   LongestWordInBook(allWords);
   KeyWordSearch(allWords);
    
    return 0;
    
}
