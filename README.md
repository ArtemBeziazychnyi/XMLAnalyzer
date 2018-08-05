The XMLAnalyzer it is a ConsoleApp which analyzes HTML and finds a specific element, even after changes, using a set of extracted attributes. 

Use cmd for run the app.

run XMLAnalyzer.exe which is located in XMLAnalyzer\XMLAnalyzer\bin\Debug with parameters.
As parameters use a pathes to the html files separate by space.
  
Example: 

> XMLAnalyzer.exe "D:\Downloads\startbootstrap-sb-admin-2-examples\sample-0-origin.html"
				"D:\Downloads\startbootstrap-sb-admin-2-examples\sample-1-evil-gemini.html"
				"D:\Downloads\startbootstrap-sb-admin-2-examples\sample-2-container-and-clone.html"
				"D:\Downloads\startbootstrap-sb-admin-2-examples\sample-3-the-escape.html"
				"D:\Downloads\startbootstrap-sb-admin-2-examples\sample-4-the-mash.html"
				
Example output:

XPath to the target element: /html[1]/a[1]
XPath to the target element: /html[1]/body[1]/a[1]



