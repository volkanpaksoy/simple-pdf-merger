# Simple PDF Merger

A simple C# console application to combine multiple PDFs into one

Usage:

	pdfMerge -d {root folder full path} -a -f {list of input files} -o {output pdf full path} 
	
	-d, --directory ....: Root folder. If file list is specified, only names without the folder can be used. The same root path is used for all files. 
	-a, --all ..........: Find and merge all PDFs in the root folder
	-f, --files ........: List of files. Full path required if direcotry is not specified
	-o, --output .......: Full path for the output PDF file