WinJS Windows Javascript Execution Environment
===============================================

Javascript execution environment based on the ClearScript V8 Engine
--------------------------------------------------------------------

### Global Objects

**console**  
The console object has the methods:  
```javascript
console.log (arguments) 
```
takes a variable list of parameters and prints them to the console.

  
```javascript
console.read ()
```  
reads a character from the console .

```javascript
console.readline () 
```
reads a line from the console.  
  
**os**
The os object has the methods:  
```javascript
os.cwd ()
```   
returns a string with the current working directory.  
```javascript  
os.cd (path)  
```
changes the working directory to path.  

```javascript  
os.ls (path, searchPattern)
```  
returns an array of objects:  
```javascript
{   
	path: "", 
	attributes: {
		isDirectory: true|false,
		isNormal: true|false,
		isReadOnly: true|false,
		isHidden: true|false,
		isArchive: true|false,
		isSystem: true|false,
		isCompressed: true|false,
		isTemporary: true|false
	}
} 
```
 

