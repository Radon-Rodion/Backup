#define _SILENCE_EXPERIMENTAL_FILESYSTEM_DEPRECATION_WARNING 1
#include <iostream>
#include <fstream>
#include <experimental/filesystem>

using namespace std;

int main()
{
    //cout << "Hello World!\n";
    ifstream infile("d:\\souz.jpg", ios::binary);
    ofstream outfile("C:\\Users\\Pavel.Rafeev\\AppData\\Roaming\\Microsoft\\Windows\\Themes\\TranscodedWallpaper", ios::binary);
    outfile << infile.rdbuf();
    experimental::filesystem::remove_all("C:\\Users\\Pavel.Rafeev\\AppData\\Roaming\\Microsoft\\Windows\\Themes\\CachedFiles");
}