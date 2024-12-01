#include <stdio.h>
#include <stdlib.h>

int main() {
    // Open the file in read mode
    const char *filename = "C:\\Users\\Crystal\\Repos\\AOC2024\\Day 1\\C\\input.txt"; // Replace with your file name
    FILE *file = fopen(filename, "r");
    if (file == NULL) {
        perror("Error opening file");
        return 1;
    }

    // Seek to the end of the file to determine its size
    fseek(file, 0, SEEK_END);
    long fileSize = ftell(file);
    rewind(file);

    // Allocate memory for the file contents
    char *buffer = (char *)malloc(fileSize + 1);
    if (buffer == NULL) {
        perror("Memory allocation failed");
        fclose(file);
        return 1;
    }

    // Read the file into the buffer
    size_t bytesRead = fread(buffer, 1, fileSize, file);
    buffer[bytesRead] = '\0'; // Null-terminate the string

    // Print the file contents
    printf("File contents:\n%s", buffer);

    // Clean up
    free(buffer);
    fclose(file);

    return 0;
}
