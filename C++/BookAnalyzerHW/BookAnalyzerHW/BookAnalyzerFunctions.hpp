//
//  BookAnalyzerFunctions.hpp
//  BookAnalyzerHW
//
//  Created by Lindsay Haslam on 9/1/23.
//

#ifndef BookAnalyzerFunctions_hpp
#define BookAnalyzerFunctions_hpp

#include <stdio.h>
#include <iostream>
#include <string>
#include <cstdlib>
#include <vector>
#include <fstream>

#endif /* BookAnalyzerFunctions_hpp */

void TitleOfBook (std::vector<std::string>& allWords);
void AuthorOfBook (std::vector<std::string>& allWords);
void NumberOfWords (std::vector<std::string> &allWords);
void NumberOfCharacters(std::ifstream& myStream);
void ShortestWordInBook(std::vector<std::string> &allWords);
void LongestWordInBook(std::vector<std::string> &allWords);
void KeyWordSearch(std::vector<std::string> &allWords);

