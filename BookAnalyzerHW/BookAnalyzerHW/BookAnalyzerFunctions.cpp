///
//  BookAnalyzerFunctions.cpp
//  BookAnalyzerHW
//
//  Created by Lindsay Haslam on 9/1/23.
//

#include "BookAnalyzerFunctions.hpp"
#include <iostream>
#include <string>
#include <cstdlib>
#include <vector>
#include <fstream>


//Find Title of Book
void TitleOfBook (std::vector<std::string> &allWords){
    int i = 0;
    while (allWords[i] != "Title:" && i < allWords.size()){
        i++;
    }
    while (allWords[i] != "Author:" && i < allWords.size()){
        std::cout<<allWords[i];
        i++;
    }
    std::cout<<std::endl;
}
                            
//Find Author of Book
void AuthorOfBook (std::vector<std::string> &allWords){
    int i = 0;
    while (allWords[i]!= "Author:" && i <allWords.size()){
        i++;
    }
    while (allWords[i] != "Translators:" && i < allWords.size()){
   std::cout<<allWords[i];
        i++;
    }
}

//Calculate Number of Words
void NumberOfWords (std::vector<std::string> &allWords){
    std::cout << "\nTotal words: " << allWords.size() << "\n";
}

//Calculate Number of Characters
void NumberOfCharacters(std::ifstream& myStream){
    char char1;
    std::vector<char> characterCount;
    myStream.clear();
    myStream.seekg( 0, std::ios::beg );
    while ( myStream >> char1){
        characterCount.push_back(char1);
    }
    std::cout << "Total chars: " << characterCount.size() << "\n";
}

//
void ShortestWordInBook(std::vector<std::string> &allWords){
    std::string shortestWord = allWords[0];
    for (int i = 0; i < allWords.size(); i++){
        if(allWords[i].size() < shortestWord.size()){
            shortestWord = allWords[i];
        }
    }
    std::cout << "Shortest word is: " << shortestWord << "\n";
}

void LongestWordInBook(std::vector<std::string> &allWords){
    std::string longestWord = allWords[0];
    for (int i = 0; i < allWords.size(); i++){
        if(allWords[i].size() > longestWord.size()){
            longestWord = allWords[i];
        }
    }
    std::cout << "Longest word is: " << longestWord << "\n";
}
void KeyWordSearch(std::vector<std::string> &allWords){
    int appearancesCounter = 0;
    std::string userKeyword = "green";
    for (int i = 0; i < allWords.size(); i++){
        if(allWords[i] == userKeyword){
            appearancesCounter++;
            
        }
    }
    std::cout << "The keyword appears " << appearancesCounter << " times: \n";
    
    //Calculate percentage
    for (int i = 0; i < allWords.size(); i++){
        if(allWords[i] == userKeyword){
            double percentangeLocation = double (i)/ allWords.size() * 100;
            if (i >= 1){
                std::cout << "at " << percentangeLocation << "%: '" << allWords[i-1] <<" "<< allWords[i] << " " << allWords[i+1] << "' \n";
            }
            
            //Account for beginning and last words
            if (i == 0){
                std::cout << "at " << percentangeLocation << "%: '" << allWords[i] <<" "<< allWords[i+1] << " " << allWords[i+2] << "' \n";
            }
            //Last place in the file
            if (i == allWords.size()-1){
                std::cout << "at " << percentangeLocation << "%: '" << allWords[i-2] <<" "<< allWords[i-1] << " " << allWords[i] << "' \n";
            }
        }
        
    }
}
