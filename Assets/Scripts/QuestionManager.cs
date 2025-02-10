using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance; // Singleton instance for easy access

    // Store questions, answers, and correct answers in a dictionary for each language and level
    private Dictionary<string, Dictionary<int, List<Question>>> questionsByLanguageAndLevel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates of the QuestionManager in the scene
        }

        // Initialize the questions
        questionsByLanguageAndLevel = new Dictionary<string, Dictionary<int, List<Question>>>
        {
            {
                "JavaScript", new Dictionary<int, List<Question>> {
                    { 1, new List<Question> {
                        new Question("What is JavaScript primarily used for?", new string[] { "Styling web pages", "Structuring web content", "Adding interactivity to web pages", "Managing databases" }, 2, "JavaScript is used to add interactivity to web pages, enabling dynamic content updates."),
                        new Question("Which keyword declares a variable?", new string[] { "var", "let", "const", "All of the above" }, 3, "All three keywords declare variables, but 'let' and 'const' are preferred for block scope."),
                        new Question("What is the output of `typeof 42`?", new string[] { "'integer'", "'number'", "'float'", "'string'" }, 1, "In JavaScript, all numbers are of type 'number', regardless of whether they are integers or floats."),
                        new Question("Which is NOT a valid data type?", new string[] { "boolean", "integer", "string", "undefined" }, 1, "JavaScript uses 'number' for both integers and floats, not 'integer' as a separate type."),
                        new Question("How do you write a single-line comment?", new string[] { "// comment", "# comment", "/* comment */", "-- comment" }, 0, "Single-line comments use '//' to mark the rest of the line as a comment."),
                        new Question("Which operator is for strict equality?", new string[] { "==", "===", "=", "!==" }, 1, "'===' checks both value and type for strict equality, unlike '==' which only compares values."),
                        new Question("Which function shows an alert?", new string[] { "alert()", "console.log()", "prompt()", "display()" }, 0, "The 'alert()' function displays a pop-up message to the user."),
                        new Question("How do you declare a function?", new string[] { "def myFunc() {}", "function myFunc() {}", "func myFunc() {}", "define myFunc() {}" }, 1, "Functions are declared using the 'function' keyword followed by the function name and parentheses."),
                        new Question("What does `console.log('Hello')` do?", new string[] { "Prints to console", "Shows an alert", "Logs error", "None" }, 0, "It prints 'Hello' to the console for debugging or display."),
                        new Question("How do you declare a constant variable?", new string[] { "const x = 5;", "let x = 5;", "var x = 5;", "constant x = 5;" }, 0, "'const' is used to declare variables whose values cannot be reassigned."),
                        new Question("What does 'NaN' mean?", new string[] { "Not a Name", "Not a Number", "Negative and Null", "None" }, 1, "'NaN' stands for 'Not a Number', indicating an invalid or unparseable number."),
                        new Question("What will `Boolean(0)` return?", new string[] { "true", "false", "0", "undefined" }, 1, "Since 0 is a falsy value, 'Boolean(0)' will return false."),
                        new Question("What does `2 + '2'` return?", new string[] { "'4'", "'22'", "4", "Error" }, 1, "When adding a number and a string, JavaScript converts the number to a string and concatenates them."),
                        new Question("How do you check if values are NOT equal?", new string[] { "!=", "==!", "!==", "><" }, 2, "'!==' checks for both value and type inequality."),
                        new Question("What does `console.log(1 + '1')` return?", new string[] { "'2'", "'11'", "'1' + 1", "Error" }, 1, "JavaScript treats '1' as a string, so it concatenates it with the number, resulting in '11'."),
                        new Question("Which method is used to remove an element from the end of an array?", new string[] { "shift()", "pop()", "unshift()", "remove()" }, 1, "The 'pop()' method removes the last element of an array."),
                        new Question("Which method is used to add an item to the end of an array?", new string[] { "push()", "append()", "add()", "unshift()" }, 0, "The 'push()' method adds an element to the end of an array."),
                        new Question("What is the result of `5 + '5'`?", new string[] { "55", "10", "5", "Error" }, 0, "JavaScript treats the number as a string, resulting in '55' when concatenated."),
                        new Question("Which of these is a correct array declaration?", new string[] { "let arr = {};", "let arr = [];", "let arr = ();", "let arr = '';" }, 1, "Arrays are declared using square brackets, e.g., 'let arr = []'."),
                        new Question("How do you define a function in JavaScript?", new string[] { "function func() {}", "def func() {}", "let func() {}", "func() {}" }, 0, "Use the 'function' keyword to define a function."),
                        new Question("What is the result of `Boolean('0')`?", new string[] { "true", "false", "0", "undefined" }, 0, "Since the string '0' is considered truthy, 'Boolean('0')' returns true."),
                        new Question("How do you check the type of a variable?", new string[] { "checkType()", "typeof", "typeOf()", "getType()" }, 1, "'typeof' is used to check the type of a variable."),
                        new Question("Which of the following is a falsy value?", new string[] { "'0'", "'false'", "'undefined'", "'1'" }, 2, "'undefined' is a falsy value, meaning it behaves like false in boolean contexts."),
                        new Question("What does `typeof null` return?", new string[] { "null", "object", "undefined", "error" }, 1, "In JavaScript, 'null' is incorrectly identified as an 'object' type."),
                        new Question("Which of the following is a valid function call?", new string[] { "func{}()", "func[]()", "func(){}", "func()" }, 3, "Functions are called using parentheses, e.g., 'func()'."),
    
                    }},
                    { 2, new List<Question> {
                        new Question("Which keyword creates a function?", new string[] { "func", "define", "function", "method" }, 2, "Functions are created with 'function'."),
                        new Question("How do you call a function named 'myFunction'?", new string[] { "call myFunction()", "myFunction()", "execute myFunction()", "run myFunction()" }, 1, "Functions are called using parentheses."),
                        new Question("Which loop is best for iterating arrays?", new string[] { "for", "while", "do-while", "switch" }, 0, "For loops are commonly used for arrays."),
                        new Question("What will `5 == '5'` return?", new string[] { "true", "false", "undefined", "error" }, 0, "'==' compares values but not types."),
                        new Question("What does `return` do in a function?", new string[] { "Stops function", "Returns a value", "Loops function", "Prints value" }, 1, "'return' sends back a value."),
                        new Question("How do you define a function expression?", new string[] { "let myFunc = function() {}", "function myFunc() {}", "def myFunc() {}", "method myFunc() {}" }, 0, "Assign function to a variable."),
                        new Question("What will `console.log(typeof [])` return?", new string[] { "'array'", "'object'", "'list'", "'undefined'" }, 1, "Arrays are objects in JavaScript."),
                        new Question("Which keyword exits a loop?", new string[] { "exit", "break", "stop", "return" }, 1, "'break' exits a loop immediately."),
                        new Question("Which syntax is correct for an if statement?", new string[] { "if x = 5 {}", "if (x == 5) {}", "if x == 5 then {}", "if x === 5 then {}" }, 1, "Use parentheses and curly braces."),
                        new Question("What does `console.log('5' + 5)` return?", new string[] { "'10'", "'55'", "10", "Error" }, 1, "JavaScript treats '5' as a string."),
                        new Question("How do you create an object?", new string[] { "let obj = [];", "let obj = {};", "let obj = ();", "let obj = '';" }, 1, "Objects are created with curly braces."),
                        new Question("Which method adds an element to an array?", new string[] { "push()", "add()", "insert()", "append()" }, 0, "push() adds elements to an array."),
                        new Question("How do you get the length of a string?", new string[] { "size()", "length()", "count()", "charAt()" }, 1, "The 'length' property returns string length."),
                        new Question("Which loop will execute at least once?", new string[] { "for", "while", "do-while", "foreach" }, 2, "'do-while' runs at least once."),
                        new Question("How do you round a number?", new string[] { "round(4.7)", "Math.round(4.7)", "ceil(4.7)", "floor(4.7)" }, 1, "Use Math.round()."),
                        new Question("Which operator is used to assign a value to a variable?", new string[] { "=", "==", "===", ":=" }, 0, "The '=' operator is used to assign values."),
                        new Question("Which method is used to get the first element of an array?", new string[] { "first()", "head()", "pop()", "shift()" }, 3, "shift() removes the first element."),
                        new Question("What is the result of `0 == false`?", new string[] { "true", "false", "undefined", "error" }, 0, "'0' is equal to false when compared using ==."),
                        new Question("How do you create a multi-line string?", new string[] { "Using backticks (`)", "Using double quotes", "Using single quotes", "Using square brackets" }, 0, "Backticks allow multi-line strings."),
                        new Question("Which loop iterates through all items in an array?", new string[] { "for", "forEach", "map", "reduce" }, 1, "forEach() is a method that iterates through an array."),
                        new Question("How do you prevent a loop from running infinitely?", new string[] { "Use break", "Use continue", "Use exit", "Use stop" }, 0, "break exits a loop immediately."),
                        new Question("Which of the following is a valid comparison operator?", new string[] { ">", "==", "<>", "==" }, 1, "Both '==' and '===' are comparison operators."),
                        new Question("What will `null == undefined` return?", new string[] { "true", "false", "error", "undefined" }, 0, "null and undefined are equal with '=='."),
                        new Question("Which function is used to parse an integer from a string?", new string[] { "parseInt()", "parseFloat()", "toInteger()", "integerParse()" }, 0, "parseInt() converts a string to an integer."),
                        new Question("What is the result of `2 == '2'`?", new string[] { "true", "false", "undefined", "error" }, 0, "'==' compares values, not types, so it returns true."),

                    }},
                    { 3, new List<Question> {
                        new Question("What is a JavaScript object?", new string[] { "A data type that stores key-value pairs", "A function", "An array", "A loop" }, 0, "Objects are data structures that store data as key-value pairs, where keys are usually strings, and the values can be any type of data."),
                        new Question("Which symbol is used to access object properties?", new string[] { ".", ":", "=>", "()" }, 0, "The dot (.) is used to access the properties or methods of an object, such as `object.property` or `object.method()`."),
                        new Question("What will `console.log(typeof [])` return?", new string[] { "'array'", "'object'", "'list'", "'undefined'" }, 1, "In JavaScript, arrays are a special kind of object, so `typeof []` returns 'object', not 'array'."),
                        new Question("How do you remove the last item from an array?", new string[] { "pop()", "remove()", "splice()", "delete()" }, 0, "'pop()' removes and returns the last item from an array, modifying the array in place."),
                        new Question("Which loop is best for iterating over an object's properties?", new string[] { "for", "forEach", "for...in", "while" }, 2, "'for...in' is used to loop over the enumerable properties of an object."),
                        new Question("What does `JSON.stringify()` do?", new string[] { "Converts JSON to a string", "Parses JSON", "Deletes JSON", "Formats JSON" }, 0, "`JSON.stringify()` converts a JavaScript object into a JSON-formatted string, which is often used for data storage or transmission."),
                        new Question("How do you check if an array contains a specific value?", new string[] { "includes()", "contains()", "hasValue()", "indexOf()" }, 0, "`includes()` checks if an array contains a certain element and returns `true` if found, otherwise `false`."),
                        new Question("What is a callback function?", new string[] { "A function passed into another function", "A function that calls itself", "A function inside a loop", "None of the above" }, 0, "A callback is a function that is passed as an argument to another function and is executed after the completion of that function."),
                        new Question("What does `setTimeout()` do?", new string[] { "Runs code immediately", "Runs code after a delay", "Loops forever", "Stops execution" }, 1, "`setTimeout()` is used to execute a function after a specified number of milliseconds, introducing a delay before running."),
                        new Question("Which method converts a string to lowercase?", new string[] { "lower()", "toLowerCase()", "convertLower()", "toLower()" }, 1, "`toLowerCase()` is a string method that converts all the characters in a string to lowercase."),
                        new Question("What is a template literal?", new string[] { "A special kind of comment", "A way to write multiline strings", "A way to use variables inside strings", "Both B and C" }, 3, "Template literals allow you to create multiline strings and embed expressions or variables inside the string using `${}`."),
                        new Question("Which method removes the first element from an array?", new string[] { "shift()", "pop()", "slice()", "splice()" }, 0, "'shift()' removes and returns the first element of an array, shifting all other elements down by one."),
                        new Question("What is the difference between `let` and `var`?", new string[] { "No difference", "'let' has block scope, 'var' does not", "'var' has block scope, 'let' does not", "'let' can be redeclared" }, 1, "`let` is block-scoped, meaning it is only accessible within the block where it is declared, while `var` is function-scoped."),
                        new Question("How do you create a promise in JavaScript?", new string[] { "new Promise()", "Promise.create()", "promise()", "newPromise()" }, 0, "A promise is created using `new Promise()`, which takes a function with `resolve` and `reject` arguments to handle asynchronous operations."),
                        new Question("Which of the following is NOT a valid object method?", new string[] { "Object.assign()", "Object.create()", "Object.duplicate()", "Object.keys()" }, 2, "Object.duplicate() is not a valid method."),
                        new Question("Which event is fired when a user clicks on an element?", new string[] { "click", "keydown", "mouseenter", "mousemove" }, 0, "The 'click' event triggers when an element is clicked."),
                        new Question("How do you check if an object contains a property?", new string[] { "has()", "contains()", "in", "indexOf()" }, 2, "The 'in' operator checks if an object has a property."),
                        new Question("What does `parseFloat('10.5')` return?", new string[] { "10", "10.5", "NaN", "undefined" }, 1, "parseFloat() converts the string '10.5' to a floating-point number."),
                        new Question("What will `console.log([1, 2] + [3, 4])` output?", new string[] { "'1,2,3,4'", "'[1,2,3,4]'", "'[1,2]' + '[3,4]'", "'Error'" }, 0, "Arrays are concatenated as strings in JavaScript."),
                    }},

                    { 4, new List<Question> {
                        new Question("What is the purpose of `try...catch`?", new string[] { "Handling errors", "Creating loops", "Defining functions", "None of the above" }, 0, "`try...catch` is used to handle exceptions and errors during code execution."),
                        new Question("How do you convert a string into a number?", new string[] { "parseInt()", "Number()", "parseFloat()", "All of the above" }, 3, "Methods like `parseInt()`, `Number()`, and `parseFloat()` can all convert strings to numbers."),
                        new Question("Which array method executes a function on each element?", new string[] { "map()", "forEach()", "filter()", "Both A and B" }, 3, "Both `map()` and `forEach()` execute a function on each element of an array."),
                        new Question("What is a closure in JavaScript?", new string[] { "A function inside a function that remembers the outer function's variables", "A loop that never ends", "A built-in function", "None of the above" }, 0, "A closure is an inner function that can access variables from its outer function even after the outer function finishes execution."),
                        new Question("What will `console.log(0.1 + 0.2 === 0.3)` return?", new string[] { "true", "false", "undefined", "error" }, 1, "It returns false because floating-point numbers may have precision issues in JavaScript."),
                        new Question("How do you copy an object?", new string[] { "Object.clone()", "copyObject()", "Object.assign({}, obj)", "obj.copy()" }, 2, "`Object.assign({}, obj)` creates a shallow copy of an object."),
                        new Question("What is `localStorage` used for?", new string[] { "Storing data in a database", "Storing temporary data", "Storing data in the browser permanently", "None of the above" }, 2, "`localStorage` stores data persistently in the browser across sessions."),
                        new Question("Which keyword is used to define an asynchronous function?", new string[] { "sync", "await", "async", "promise" }, 2, "`async` is used to define a function that runs asynchronously and can use `await` to handle promises."),
                        new Question("What does `fetch()` do?", new string[] { "Fetches data from an API", "Creates a new function", "Loops through an array", "None of the above" }, 0, "`fetch()` retrieves resources, like data from an API, asynchronously."),
                        new Question("Which method sorts an array?", new string[] { "order()", "sort()", "arrange()", "setOrder()" }, 1, "`sort()` is used to sort the elements of an array in place."),
                        new Question("What will `console.log(typeof NaN)` return?", new string[] { "'undefined'", "'null'", "'number'", "'NaN'" }, 2, "`NaN` is a special value that represents 'Not-A-Number', but it’s still of type `number` in JavaScript."),
                        new Question("How do you merge two arrays?", new string[] { "concat()", "merge()", "combine()", "add()" }, 0, "`concat()` merges two arrays into one array."),
                        new Question("What will `console.log([1,2,3] instanceof Array)` return?", new string[] { "true", "false", "undefined", "error" }, 0, "`instanceof` checks if an object is an instance of a specified type, such as an array."),
                        new Question("Which method finds the first element that passes a condition?", new string[] { "find()", "filter()", "map()", "forEach()" }, 0, "`find()` returns the first element in an array that satisfies the given condition."),
                        new Question("What will `console.log(5 + true)` return?", new string[] { "5", "6", "true5", "Error" }, 1, "`true` is coerced to `1`, so `5 + 1` equals `6`."),
                        new Question("How do you check if an object contains a property?", new string[] { "has()", "contains()", "in", "indexOf()" }, 2, "The 'in' operator checks if an object has a property."),
                        new Question("Which method is used to join two arrays?", new string[] { "join()", "combine()", "concat()", "merge()" }, 2, "The 'concat()' method is used to combine two or more arrays."),
                        new Question("How do you create an array?", new string[] { "let arr = (1,2,3);", "let arr = {1,2,3};", "let arr = [1,2,3];", "let arr = '1,2,3';" }, 2, "Arrays are created using square brackets, e.g., 'let arr = [1,2,3];'."),

                    }},

                }
            },
            {
                "Java", new Dictionary<int, List<Question>> {
                   { 1, new List<Question> {
                        new Question("What is Java?", new string[] { "A programming language", "A framework", "A text editor", "None of the above" }, 0, "Java is a high-level, object-oriented programming language used to develop web applications, mobile apps, and more."),
                        new Question("What does JVM stand for?", new string[] { "Java Variable Memory", "Java Virtual Machine", "Java Versatile Model", "None of the above" }, 1, "JVM stands for Java Virtual Machine, which allows Java programs to run on different devices by abstracting the underlying hardware."),
                        new Question("Which keyword is used to create a class in Java?", new string[] { "class", "new", "create", "object" }, 0, "The 'class' keyword is used to define a class in Java, which serves as the blueprint for objects."),
                        new Question("Which of the following is a primitive data type in Java?", new string[] { "int", "String", "Object", "Array" }, 0, "In Java, 'int' is a primitive data type, used to represent integer values."),
                        new Question("What is the correct way to declare a variable in Java?", new string[] { "int a;", "variable int a;", "a int;", "declare int a;" }, 0, "In Java, the correct way to declare a variable is to specify the data type followed by the variable name, e.g., 'int a;'"),
                        new Question("Which of the following is the correct syntax for creating a new object?", new string[] { "new Object();", "Object object = new Object();", "Object = new object();", "object = new Object;" }, 1, "To create a new object, we use 'new Object();' and assign it to a variable."),
                        new Question("What is the default value of a boolean variable in Java?", new string[] { "true", "false", "0", "null" }, 1, "In Java, the default value of a boolean variable is 'false'."),
                        new Question("What is the size of an 'int' in Java?", new string[] { "32 bits", "64 bits", "16 bits", "8 bits" }, 0, "In Java, an 'int' is 32 bits in size."),
                        new Question("What is the correct way to comment a single line in Java?", new string[] { "// comment", "# comment", "/* comment */", "// comment */" }, 0, "In Java, single-line comments are written using '//'"),
                        new Question("Which operator is used to compare two values in Java?", new string[] { "=", "==", ">", "!=" }, 1, "The '==' operator is used to compare two values in Java."),
                        new Question("What is the method signature for the main method in Java?", new string[] { "public static void main(String[] args)", "static void main(String[] args)", "public void main(String[] args)", "void main(String[] args)" }, 0, "The main method in Java must be defined as 'public static void main(String[] args)'."),
                        new Question("How do you define a constant in Java?", new string[] { "final", "static", "constant", "immutable" }, 0, "In Java, constants are defined using the 'final' keyword."),
                        new Question("Which data type is used to store a character in Java?", new string[] { "char", "string", "Character", "int" }, 0, "In Java, 'char' is used to store a single character."),
                        new Question("Which keyword is used to create a subclass in Java?", new string[] { "extends", "inherits", "super", "new" }, 0, "In Java, the 'extends' keyword is used to create a subclass."),
                        new Question("Which method is used to convert a string to an integer?", new string[] { "parseInt()", "toInteger()", "convert()", "int()" }, 0, "The 'parseInt()' method is used to convert a string to an integer in Java."),
                        new Question("Which of the following is not a valid Java identifier?", new string[] { "123abc", "_abc123", "$abc123", "abc123" }, 0, "Identifiers in Java cannot start with a digit, so '123abc' is not a valid identifier."),
                        new Question("Which of the following is the correct syntax to call a method in Java?", new string[] { "myMethod()", "call myMethod()", "myMethod.call()", "myMethod;()" }, 0, "In Java, you call a method using its name followed by parentheses, e.g., 'myMethod();'."),
                        new Question("What type of variable cannot be changed after initialization?", new string[] { "final", "static", "const", "mutable" }, 0, "'final' variables cannot be changed after initialization in Java."),
                        new Question("Which of these is a collection class in Java?", new string[] { "ArrayList", "int[]", "String", "Object" }, 0, "'ArrayList' is a collection class in Java."),
                        new Question("Which of these is a valid data type for a method's return type?", new string[] { "String", "void", "int", "All of the above" }, 3, "In Java, a method can have 'String', 'void', or 'int' as its return type."),
                        new Question("What is the default value of a reference variable in Java?", new string[] { "null", "0", "undefined", "false" }, 0, "The default value of a reference variable in Java is 'null'."),
                        new Question("Which type of loop will always execute at least once?", new string[] { "do-while loop", "for loop", "while loop", "for-each loop" }, 0, "The 'do-while' loop always executes at least once because the condition is checked after execution."),
                        new Question("Which of the following is used to remove an element from a list in Java?", new string[] { "remove()", "delete()", "erase()", "pop()" }, 0, "'remove()' is used to remove an element from a list in Java."),
                        new Question("Which class is used to read data from the console in Java?", new string[] { "Scanner", "BufferedReader", "FileReader", "DataInputStream" }, 0, "The 'Scanner' class is commonly used to read data from the console in Java."),
                        new Question("What does the 'continue' statement do in a loop?", new string[] { "Skips the current iteration and proceeds to the next one", "Terminates the loop", "Exits the loop and continues execution", "None of the above" }, 0, "The 'continue' statement skips the current iteration and proceeds to the next one in a loop.")
                    }},
                    { 2, new List<Question> {
                        new Question("What is the purpose of a constructor in Java?", new string[] { "Initialize objects", "Store data", "Create variables", "None of the above" }, 0, "A constructor in Java is used to initialize objects when they are created, typically setting initial values."),
                        new Question("Which of the following is not a Java primitive data type?", new string[] { "int", "char", "boolean", "object" }, 3, "'object' is not a primitive data type in Java. Objects are instances of classes, which are reference types."),
                        new Question("What is the correct way to handle exceptions in Java?", new string[] { "try-catch block", "throw-try block", "catch-finally block", "None of the above" }, 0, "Java uses a 'try-catch' block to handle exceptions. Code that may throw exceptions is placed inside the 'try' block, and the exceptions are handled in the 'catch' block."),
                        new Question("What is the size of a 'long' data type in Java?", new string[] { "64 bits", "32 bits", "128 bits", "8 bits" }, 0, "In Java, the 'long' data type is 64 bits in size."),
                        new Question("What does the 'final' keyword do in Java?", new string[] { "Prevents method overriding", "Declares constants", "Prevents inheritance", "All of the above" }, 3, "The 'final' keyword in Java can be used to prevent method overriding, make a variable a constant, or prevent class inheritance."),
                        new Question("What does 'System.out.println()' do?", new string[] { "Prints text to the console", "Creates a new line", "Closes the program", "Returns a value" }, 0, "'System.out.println()' prints a message to the console and moves to the next line."),
                        new Question("Which of the following is a wrapper class in Java?", new string[] { "Integer", "int", "char", "double" }, 0, "In Java, 'Integer' is a wrapper class for the primitive data type 'int'."),
                        new Question("Which loop is used when the number of iterations is known in advance?", new string[] { "for loop", "while loop", "do-while loop", "foreach loop" }, 0, "A 'for' loop is used when the number of iterations is known beforehand."),
                        new Question("What is the 'break' statement used for?", new string[] { "To terminate a loop or switch", "To skip to the next iteration", "To pause the program", "None of the above" }, 0, "The 'break' statement is used to exit a loop or switch statement prematurely."),
                        new Question("Which method is used to find the length of an array?", new string[] { "length()", "size()", "length", "count()" }, 2, "The 'length' property is used to find the length of an array in Java."),
                        new Question("Which of the following is the correct way to declare a method in Java?", new string[] { "public void myMethod()", "void myMethod()", "method void myMethod()", "myMethod() void" }, 0, "The correct way to declare a method is 'public void myMethod()' in Java."),
                        new Question("Which of the following is used to handle a method in Java that may throw an exception?", new string[] { "try-catch", "throw", "throws", "None of the above" }, 0, "A 'try-catch' block is used to handle exceptions in Java."),
                        new Question("What does the 'super' keyword refer to in Java?", new string[] { "The parent class", "The current object", "A static method", "A constructor" }, 0, "The 'super' keyword in Java refers to the parent class of the current object and can be used to access parent class methods or constructors."),
                        new Question("What is the purpose of the 'instanceof' keyword?", new string[] { "Check if an object is an instance of a class", "Create an object", "Declare an object", "Assign a class" }, 0, "'instanceof' checks whether an object is an instance of a specific class or subclass."),
                        new Question("Which operator is used to assign a value to a variable in Java?", new string[] { "=", "==", "<>", "!=" }, 0, "The '=' operator is used to assign a value to a variable."),
                        new Question("What is the purpose of the 'this' keyword?", new string[] { "Refers to the current object", "Refers to a parent class", "Refers to a variable", "None of the above" }, 0, "'this' refers to the current object in Java."),
                        new Question("Which of the following is used to define an interface in Java?", new string[] { "interface", "abstract", "implements", "class" }, 0, "The 'interface' keyword is used to define an interface in Java."),
                        new Question("How do you declare a method that doesn't return a value?", new string[] { "void", "int", "boolean", "String" }, 0, "A method that doesn't return a value is declared with the 'void' keyword."),
                        new Question("What is the output of 'System.out.println(10 / 3);' in Java?", new string[] { "3", "3.0", "3.333", "10/3" }, 0, "In Java, integer division results in an integer value, so '10 / 3' prints '3'."),
                        new Question("What is the default value of a reference variable?", new string[] { "null", "0", "false", "undefined" }, 0, "The default value of a reference variable is 'null' in Java."),
                        new Question("Which of the following is an example of method overloading?", new string[] { "Method with different parameters", "Method with the same parameters", "Method with the same name and return type", "None of the above" }, 0, "Method overloading occurs when a method has the same name but different parameters."),
                        new Question("Which of these keywords is used to inherit a class?", new string[] { "extends", "implements", "this", "super" }, 0, "'extends' is used to inherit a class in Java."),
                        new Question("Which of the following is a valid declaration of an array?", new string[] { "int[] arr;", "int arr[];", "int arr[5];", "Both a and b" }, 3, "Both 'int[] arr;' and 'int arr[];' are valid ways to declare an array in Java.")
                    }},
                    { 3, new List<Question> {
                        new Question("What is the default value of an integer in Java?", new string[] { "0", "null", "undefined", "1" }, 0, "In Java, the default value of an uninitialized integer is 0."),
                        new Question("Which keyword is used to prevent a method from being overridden in Java?", new string[] { "final", "static", "private", "public" }, 0, "The 'final' keyword prevents a method from being overridden in subclasses in Java."),
                        new Question("What does the 'super' keyword refer to in Java?", new string[] { "The parent class", "The current object", "A static method", "A constructor" }, 0, "The 'super' keyword in Java refers to the parent class of the current object and can be used to access parent class methods or constructors."),
                        new Question("What is the purpose of the 'this' keyword in Java?", new string[] { "Refers to the current object", "Refers to the superclass", "Refers to a variable", "None of the above" }, 0, "'this' refers to the current object in Java, allowing access to its members and distinguishing between local and instance variables."),
                        new Question("What is an interface in Java?", new string[] { "A class that implements multiple classes", "A blueprint for classes", "A type of method", "A primitive data type" }, 1, "An interface is a blueprint for classes, containing abstract methods that need to be implemented by classes."),
                        new Question("Which access modifier is the most restrictive in Java?", new string[] { "private", "protected", "public", "default" }, 0, "'private' is the most restrictive access modifier in Java."),
                        new Question("Which of the following methods can be used to read input from the user in Java?", new string[] { "Scanner.nextInt()", "readLine()", "System.in", "input.next()" }, 0, "'Scanner.nextInt()' is used to read integers from the user in Java."),
                        new Question("What does the 'instanceof' keyword do in Java?", new string[] { "Checks if an object is an instance of a class", "Creates a new instance of a class", "Declares a new object", "None of the above" }, 0, "'instanceof' checks whether an object is an instance of a specified class or subclass."),
                        new Question("Which of the following can store multiple values in Java?", new string[] { "Array", "Variable", "Integer", "Character" }, 0, "An 'array' is used to store multiple values of the same type in Java."),
                        new Question("Which of the following is used to terminate a loop early in Java?", new string[] { "continue", "break", "exit", "end" }, 1, "The 'break' statement is used to exit a loop prematurely."),
                        new Question("What is the return type of the 'toString()' method in Java?", new string[] { "String", "Object", "char", "int" }, 0, "'toString()' method returns a String representation of an object in Java."),
                        new Question("Which of these is a type of collection in Java?", new string[] { "List", "Integer", "String", "Boolean" }, 0, "A 'List' is one of the collection types in Java."),
                        new Question("What is a constructor in Java?", new string[] { "A method that is called when an object is created", "A method that is executed on every loop", "A type of class", "None of the above" }, 0, "A constructor is a special method that is called when an object is created."),
                        new Question("What is an abstract class in Java?", new string[] { "A class with only abstract methods", "A class that cannot be instantiated", "A class without constructors", "None of the above" }, 1, "An abstract class cannot be instantiated directly and may contain abstract methods that must be implemented by subclasses."),
                        new Question("Which keyword is used to create a constant in Java?", new string[] { "static", "const", "final", "immutable" }, 2, "In Java, constants are created using the 'final' keyword."),
                        new Question("Which of the following is used to import a class in Java?", new string[] { "import", "include", "use", "require" }, 0, "The 'import' keyword is used to include classes or packages into a Java program."),
                        new Question("What does the 'new' keyword do in Java?", new string[] { "Creates an object", "Creates a variable", "Creates a constructor", "None of the above" }, 0, "'new' is used to create new objects in Java."),
                        new Question("What is the size of a 'char' in Java?", new string[] { "2 bytes", "4 bytes", "8 bytes", "16 bytes" }, 0, "In Java, a 'char' is stored as 2 bytes (16 bits)."),
                        new Question("Which of these methods is used to sort an array in Java?", new string[] { "Arrays.sort()", "List.sort()", "Array.sort()", "None of the above" }, 0, "The 'Arrays.sort()' method is used to sort arrays in Java."),
                        new Question("What is the default value of a boolean in Java?", new string[] { "true", "false", "0", "null" }, 1, "The default value of a boolean variable in Java is 'false'."),
                        new Question("Which method is used to append text to a StringBuffer in Java?", new string[] { "append()", "concat()", "add()", "insert()" }, 0, "The 'append()' method is used to add text to a StringBuffer in Java."),
                        new Question("What is the purpose of the 'super()' constructor in Java?", new string[] { "To call a constructor from the parent class", "To call the current class constructor", "To initialize a variable", "None of the above" }, 0, "'super()' is used to call the constructor of the parent class in Java."),
                        new Question("Which of the following is a method of the String class?", new string[] { "length()", "size()", "count()", "index()" }, 0, "The 'length()' method is used to find the length of a String in Java."),
                        new Question("Which of the following is not a valid loop in Java?", new string[] { "while", "do-while", "foreach", "loop-while" }, 3, "'loop-while' is not a valid loop in Java.")
                    }},
                    { 4, new List<Question> {
                        new Question("Which of the following is not a valid way to define a method in Java?", new string[] { "public void myMethod()", "void public myMethod()", "public static void myMethod()", "private void myMethod()" }, 1, "The 'void public myMethod()' is not a valid method definition in Java."),
                        new Question("Which of the following keywords is used to define a subclass?", new string[] { "extends", "implements", "super", "default" }, 0, "'extends' is used to define a subclass in Java."),
                        new Question("What is method overloading in Java?", new string[] { "Defining multiple methods with the same name but different parameters", "Defining multiple methods with the same parameters", "Creating methods that do not return values", "None of the above" }, 0, "Method overloading occurs when you define multiple methods with the same name but different parameters."),
                        new Question("What is method overriding in Java?", new string[] { "Rewriting a method in a subclass", "Defining a method with no return type", "Calling a method from another class", "None of the above" }, 0, "Method overriding is when a subclass provides a specific implementation for a method that is already defined in its superclass."),
                        new Question("What does the 'final' keyword do in Java?", new string[] { "Prevents method overriding", "Declares constants", "Prevents inheritance", "All of the above" }, 3, "The 'final' keyword can prevent method overriding, declare constants, or prevent class inheritance."),
                        new Question("Which of these is a valid loop in Java?", new string[] { "for", "while", "do-while", "All of the above" }, 3, "Java supports all of the mentioned loop types: 'for', 'while', and 'do-while'."),
                        new Question("What does the 'continue' statement do in Java?", new string[] { "Skip the current iteration and proceed to the next iteration", "Exit the loop", "Terminate the program", "None of the above" }, 0, "'continue' skips the current iteration of a loop and moves to the next one."),
                        new Question("What is the correct syntax to create a new thread in Java?", new string[] { "new Thread()", "Thread t = new Thread();", "Thread t = new Thread()", "new Thread(t);" }, 1, "To create a new thread in Java, use 'Thread t = new Thread();' and then start the thread."),
                        new Question("What does the 'synchronized' keyword do?", new string[] { "Locks a method to allow only one thread to execute it", "Makes a method accessible to all threads", "Executes code asynchronously", "None of the above" }, 0, "'synchronized' locks a method so that only one thread can execute it at a time."),
                        new Question("Which method is used to start a thread in Java?", new string[] { "start()", "begin()", "run()", "execute()" }, 0, "'start()' is used to begin the execution of a thread in Java."),
                        new Question("Which of these is used to declare a method in Java?", new string[] { "void", "method", "public", "static" }, 0, "'void' is used to define a method that does not return any value."),
                        new Question("What is the size of an integer in Java?", new string[] { "4 bytes", "8 bytes", "16 bytes", "2 bytes" }, 0, "An integer ('int') in Java is 4 bytes in size."),
                        new Question("Which keyword is used to make a class or method accessible only within its own package?", new string[] { "public", "protected", "private", "default" }, 3, "The 'default' access modifier allows access only within the same package in Java."),
                        new Question("Which method in Java is used to compare two strings?", new string[] { "equals()", "compare()", "compareTo()", "isEqual()" }, 2, "'compareTo()' is used to compare two strings lexicographically in Java."),
                        new Question("Which method is used to get the hash code of an object in Java?", new string[] { "hash()", "hashCode()", "getHash()", "objectHash()" }, 1, "The 'hashCode()' method returns the hash code of an object in Java."),
                        new Question("Which method is used to parse a string into a number in Java?", new string[] { "parseInt()", "convert()", "toNumber()", "parse()" }, 0, "The 'parseInt()' method is used to convert a string into an integer in Java."),
                        new Question("What is the correct syntax for a switch statement in Java?", new string[] { "switch(expression) { case 1: ... }", "switch(expression): case 1: ...", "switch expression { case 1: ... }", "switch case { 1: ... }" }, 0, "The correct syntax for a switch statement is 'switch(expression) { case 1: ... }'."),
                        new Question("What is the return type of the 'toString()' method?", new string[] { "String", "Object", "char", "int" }, 0, "The 'toString()' method in Java returns a String."),
                        new Question("Which exception is thrown when an array index is out of bounds in Java?", new string[] { "IndexOutOfBoundsException", "ArrayIndexOutOfBoundsException", "OutOfBoundsException", "InvalidIndexException" }, 1, "The 'ArrayIndexOutOfBoundsException' is thrown when an array index is out of bounds in Java."),
                        new Question("Which collection type allows duplicates in Java?", new string[] { "Set", "List", "Map", "Queue" }, 1, "The 'List' collection type allows duplicate elements in Java.")
                    }}
                }
            },
            {
                "C#", new Dictionary<int, List<Question>> {
                    { 1, new List<Question> {
                        new Question("What is C#?", new string[] { "A programming language", "A software framework", "A database", "None of the above" }, 0, "C# (C-Sharp) is a modern, object-oriented programming language developed by Microsoft."),
                        new Question("Which of the following types is used for nullable value types in C#?", new string[] { "Nullable<T>", "T?", "Null<T>", "Option<T>" }, 1, "In C#, 'T?' is used for nullable value types, meaning the type can also represent 'null'."),
                        new Question("Which of the following methods is used to convert a string to an integer in C#?", new string[] { "ToInt()", "Parse()", "ConvertToInt()", "ToInteger()" }, 1, "The 'Parse()' method in C# is used to convert a string to an integer."),
                        new Question("Which keyword is used to create a subclass in C#?", new string[] { "inherits", "extends", "base", ":" }, 3, "In C#, the ':' character is used to indicate inheritance when creating a subclass from a base class."),
                        new Question("Which of the following is not a valid access modifier in C#?", new string[] { "public", "private", "protected", "exclusive" }, 3, "'exclusive' is not a valid access modifier in C#."),
                        new Question("Which of these is a valid way to declare a variable in C#?", new string[] { "int num;", "integer num;", "Num = 0;", "var num = string;" }, 0, "In C#, you declare an integer variable using 'int num;'."),
                        new Question("What is the default value of a boolean in C#?", new string[] { "true", "false", "null", "0" }, 1, "The default value of a boolean variable in C# is 'false'."),
                        new Question("Which keyword is used to define a constant value in C#?", new string[] { "const", "static", "readonly", "immutable" }, 0, "The 'const' keyword is used to define constants in C#."),
                        new Question("Which of the following loops is not available in C#?", new string[] { "for", "while", "foreach", "repeat-until" }, 3, "'repeat-until' is not a valid loop in C#."),
                        new Question("Which symbol is used to define a single-line comment in C#?", new string[] { "//", "/* */", "#", "--" }, 0, "Single-line comments in C# are written using '//'."),
                        new Question("What is the main entry point of a C# program?", new string[] { "Main()", "Start()", "Run()", "Begin()" }, 0, "In C#, execution starts from the 'Main()' method."),
                        new Question("What is the output of 'Console.WriteLine(5 / 2);' in C#?", new string[] { "2", "2.5", "2.0", "Error" }, 0, "Since both operands are integers, the division returns an integer result: 2."),
                        new Question("Which method is used to take user input from the console in C#?", new string[] { "Console.Read()", "Console.ReadLine()", "Input()", "Scanner()" }, 1, "'Console.ReadLine()' is used to take user input in C#."),
                        new Question("What is the use of the 'break' statement in C# loops?", new string[] { "To exit the loop", "To continue to the next iteration", "To pause execution", "To restart the loop" }, 0, "The 'break' statement is used to exit a loop early in C#."),
                        new Question("Which keyword is used to handle exceptions in C#?", new string[] { "catch", "exception", "try", "handle" }, 2, "The 'try' block is used to handle exceptions in C#."),
                        new Question("What is the correct syntax to declare a string variable in C#?", new string[] { "string name;", "String name;", "var name;", "All of the above" }, 3, "All options correctly declare a string variable in C#. 'string' and 'String' are interchangeable."),
                        new Question("Which keyword is used to exit a loop immediately?", new string[] { "break", "continue", "exit", "return" }, 0, "The 'break' statement is used to exit a loop immediately."),
                        new Question("Which function is used to display text on the console in C#?", new string[] { "Console.Write()", "Console.Print()", "Console.Display()", "Console.Output()" }, 0, "'Console.Write()' is used to display text on the console."),
                        new Question("What will 'Console.WriteLine(10 % 3);' output?", new string[] { "1", "3", "0", "10" }, 0, "10 % 3 returns the remainder, which is 1."),
                        new Question("Which keyword is used to create a loop in C#?", new string[] { "loop", "for", "repeat", "while" }, 1, "'for' and 'while' are both used to create loops in C#. 'for' is the most common."),
                        new Question("What is the correct way to check if two values are equal in C#?", new string[] { "=", "==", "!=", "Equals()" }, 1, "'==' is used to compare two values for equality in C#."),
                        new Question("What is the default value of an integer variable in C#?", new string[] { "0", "1", "null", "undefined" }, 0, "Integer variables in C# default to 0."),
                        new Question("Which of the following is a valid way to initialize an integer variable?", new string[] { "int num = 10;", "int num(10);", "num = int(10);", "integer num = 10;" }, 0, "'int num = 10;' correctly initializes an integer variable."),
                        new Question("Which function is used to pause the console until the user presses Enter?", new string[] { "Console.Read()", "Console.ReadLine()", "Console.Wait()", "Console.Pause()" }, 1, "'Console.ReadLine()' waits for user input before continuing."),
                        new Question("What is the purpose of the 'return' statement in a method?", new string[] { "To exit the method and return a value", "To stop execution", "To repeat a loop", "To create a variable" }, 0, "'return' is used to exit a method and optionally return a value.")
                    }},
                    { 2, new List<Question> {
                        new Question("What is a 'struct' in C#?", new string[] { "A value type that can hold multiple values", "A reference type", "A class type", "None of the above" }, 0, "A 'struct' is a value type in C# that can hold multiple values but is stored on the stack."),
                        new Question("What is a 'readonly' field in C#?", new string[] { "A field that can only be assigned once", "A field with a constant value", "A field that is mutable", "A field defined with the 'static' keyword" }, 0, "'readonly' fields can only be assigned once, either at declaration or in a constructor."),
                        new Question("Which method is used to compare two strings in C#?", new string[] { "compare()", "Equals()", "==", "compareTo()" }, 1, "'Equals()' is used to compare string values in C#."),
                        new Question("Which collection type does not allow duplicate values?", new string[] { "List", "Array", "HashSet", "Queue" }, 2, "'HashSet' does not allow duplicate values in C#."),
                        new Question("What is the size of an 'int' in C#?", new string[] { "2 bytes", "4 bytes", "8 bytes", "16 bytes" }, 1, "In C#, an 'int' is 4 bytes in size."),
                        new Question("Which keyword is used to create an interface in C#?", new string[] { "interface", "class", "struct", "implements" }, 0, "'interface' is used to define interfaces in C#."),
                        new Question("Which method is used to get the length of an array in C#?", new string[] { "size()", "length()", "Length", "count()" }, 2, "The 'Length' property is used to get the size of an array in C#."),
                        new Question("Which of these is used to declare a method in C#?", new string[] { "function", "method", "void", "return" }, 2, "'void' is used to declare a method that does not return any value."),
                        new Question("Which operator is used to concatenate strings in C#?", new string[] { "+", "-", "*", "&" }, 0, "The '+' operator is used to concatenate strings in C#."),
                        new Question("Which keyword is used to define a static method in C#?", new string[] { "static", "void", "const", "method" }, 0, "The 'static' keyword is used to define static methods."),
                        new Question("Which of the following is not a valid loop in C#?", new string[] { "for", "while", "foreach", "do-next" }, 3, "'do-next' is not a valid loop in C#."),
                        new Question("Which of the following is a reference type in C#?", new string[] { "int", "double", "class", "char" }, 2, "'class' is a reference type in C#."),
                        new Question("What is the purpose of the 'finally' block in C#?", new string[] { "To execute code after an exception", "To define an exception", "To catch an error", "To exit the program" }, 0, "The 'finally' block is used to execute code after a 'try' block, regardless of whether an exception occurs."),
                        new Question("What is the output of '5 % 2' in C#?", new string[] { "1", "2", "0", "5" }, 0, "The '%' operator returns the remainder, so 5 % 2 = 1."),
                        new Question("Which keyword is used to create an object of a class in C#?", new string[] { "new", "create", "instantiate", "object" }, 0, "The 'new' keyword is used to create an instance of a class."),
                        new Question("Which of the following is NOT a valid data type in C#?", new string[] { "int", "double", "float", "character" }, 3, "The correct term in C# is 'char', not 'character'."),
                        new Question("Which operator is used to check if two conditions are both true?", new string[] { "&&", "||", "!", "&" }, 0, "'&&' is the logical AND operator."),
                        new Question("Which method is used to remove an item from a list by its value?", new string[] { "Remove()", "Delete()", "Erase()", "Pop()" }, 0, "'Remove()' removes an item from a list by value."),
                        new Question("Which statement is used to skip the current iteration of a loop in C#?", new string[] { "break", "continue", "return", "skip" }, 1, "'continue' is used to skip the current iteration and move to the next."),
                        new Question("Which of the following correctly declares an array in C#?", new string[] { "int[] numbers = new int[5];", "array<int> numbers;", "int numbers = [];", "int array numbers = new int();" }, 0, "'int[] numbers = new int[5];' correctly declares an array."),
                        new Question("Which function is used to convert an integer to a string in C#?", new string[] { "ToString()", "ConvertToString()", "Parse()", "String()" }, 0, "'ToString()' converts an integer to a string."),
                        new Question("Which keyword is used to declare a method that belongs to a class and not an instance?", new string[] { "static", "class", "void", "method" }, 0, "'static' makes a method belong to a class rather than an instance."),
                        new Question("What does the 'is' keyword do in C#?", new string[] { "Checks if an object is of a certain type", "Assigns a value", "Compares two variables", "Creates an instance" }, 0, "'is' checks if an object is of a specific type.")
                    }},
                    { 3, new List<Question> {
                        new Question("Which keyword is used to define a method in an interface?", new string[] { "void", "method", "abstract", "No keyword is needed" }, 3, "In an interface, methods are implicitly public and abstract, so no keyword is required."),
                        new Question("Which of the following is a valid way to initialize a List in C#?", new string[] { "List<int> myList = new List<int>();", "List myList = new List();", "List<int> myList = List<int>();", "var myList = new List<int>[10];" }, 0, "'List<int> myList = new List<int>();' correctly initializes a List in C#."),
                        new Question("Which statement is used to handle exceptions in C#?", new string[] { "try-catch", "handle-error", "exception-try", "error-handling" }, 0, "'try-catch' is used for handling exceptions in C#."),
                        new Question("Which operator is used for logical AND in C#?", new string[] { "&&", "||", "&", "AND" }, 0, "'&&' is the logical AND operator in C#."),
                        new Question("How do you declare a nullable integer in C#?", new string[] { "int? num;", "int num = null;", "nullable int num;", "int null num;" }, 0, "In C#, nullable value types are declared using '?', e.g., 'int? num;'."),
                        new Question("Which class is used for file handling in C#?", new string[] { "File", "Stream", "Document", "System.IO" }, 0, "The 'File' class in the 'System.IO' namespace is used for file handling in C#."),
                        new Question("Which method is used to convert a string to lowercase in C#?", new string[] { "ToLower()", "to_lower()", "lower()", "ConvertToLower()" }, 0, "'ToLower()' converts a string to lowercase in C#."),
                        new Question("What is the purpose of the 'using' statement in C#?", new string[] { "To include a namespace", "To define a loop", "To declare a class", "To allocate memory" }, 0, "The 'using' statement is used to include namespaces in C#."),
                        new Question("Which keyword is used to inherit a class in C#?", new string[] { "inherits", "base", "extends", ":" }, 3, "C# uses the ':' symbol to indicate inheritance."),
                        new Question("Which data type should be used for precise decimal calculations in C#?", new string[] { "float", "double", "decimal", "int" }, 2, "'decimal' is used for precise calculations involving currency or financial data."),
                        new Question("Which method is used to remove the last element from a List in C#?", new string[] { "RemoveAt()", "DeleteLast()", "Pop()", "RemoveLast()" }, 0, "'RemoveAt()' can be used with 'list.Count - 1' to remove the last element."),
                        new Question("Which collection in C# does not allow duplicate values?", new string[] { "List", "Queue", "HashSet", "Array" }, 2, "'HashSet' does not allow duplicate values."),
                        new Question("Which of the following is a valid way to check if a key exists in a Dictionary?", new string[] { "dict.ContainsKey(key)", "dict.HasKey(key)", "dict[key] != null", "dict.ExistKey(key)" }, 0, "'ContainsKey()' is used to check if a key exists in a Dictionary."),
                        new Question("Which type of class cannot be instantiated in C#?", new string[] { "Abstract class", "Static class", "Both A and B", "None of the above" }, 2, "Both abstract and static classes cannot be instantiated in C#."),
                        new Question("What is the purpose of the 'virtual' keyword in C#?", new string[] { "Allows a method to be overridden", "Makes a class abstract", "Declares a new method", "None of the above" }, 0, "'virtual' allows a method to be overridden in derived classes."),
                        new Question("Which keyword is used to prevent method overriding in C#?", new string[] { "sealed", "static", "final", "override" }, 0, "'sealed' prevents a method from being overridden in C#."),
                        new Question("Which of the following is NOT a valid C# interface declaration?", new string[] { "interface IExample {}", "public interface IExample {}", "interface IExample { void Method() {} }", "interface IExample { void Method(); }" }, 2, "Interfaces cannot have method implementations unless they are default implementations."),
                        new Question("What is the purpose of the 'params' keyword in C#?", new string[] { "Allows a method to accept a variable number of arguments", "Declares optional parameters", "Makes a parameter required", "None of the above" }, 0, "'params' allows a method to accept a variable number of arguments."),
                        new Question("Which data structure uses a FIFO (First In, First Out) approach?", new string[] { "Stack", "Queue", "List", "Dictionary" }, 1, "'Queue' follows a First In, First Out (FIFO) structure."),
                        new Question("Which of the following statements about C# delegates is true?", new string[] { "Delegates are type-safe function pointers", "Delegates can store multiple methods", "Delegates can be used for callbacks", "All of the above" }, 3, "Delegates are type-safe function pointers that support multiple methods and callbacks."),
                        new Question("Which operator is used to perform a null-coalescing operation in C#?", new string[] { "??", "?:", "==", "&&" }, 0, "'??' is the null-coalescing operator in C#."),
                        new Question("Which method is used to stop a running thread in C#?", new string[] { "Abort()", "Stop()", "Terminate()", "End()" }, 0, "'Abort()' is used to stop a running thread, though it's not recommended due to potential issues.")
                    }},
                    { 4, new List<Question> {
                        new Question("What is the purpose of the 'async' keyword in C#?", new string[] { "Defines an asynchronous method", "Defines a background thread", "Stops execution", "None of the above" }, 0, "The 'async' keyword is used to define asynchronous methods in C#."),
                        new Question("Which method is used to join strings in C#?", new string[] { "String.Join()", "String.Concat()", "String.Merge()", "String.Combine()" }, 0, "'String.Join()' is used to join multiple strings in C#."),
                        new Question("Which of the following is used for thread synchronization in C#?", new string[] { "lock", "mutex", "semaphore", "All of the above" }, 3, "'lock', 'mutex', and 'semaphore' are all used for thread synchronization in C#."),
                        new Question("Which access modifier allows a method to be accessed only within the same assembly?", new string[] { "private", "protected", "internal", "public" }, 2, "'internal' allows access within the same assembly in C#."),
                        new Question("Which collection allows key-value pairs in C#?", new string[] { "List", "Dictionary", "Array", "Queue" }, 1, "'Dictionary' stores key-value pairs in C#."),
                        new Question("What does 'sealed' do in C#?", new string[] { "Prevents inheritance", "Allows only one instance", "Makes a variable constant", "None of the above" }, 0, "'sealed' prevents a class from being inherited in C#."),
                        new Question("Which class is used to work with JSON in C#?", new string[] { "JsonSerializer", "JsonConverter", "System.Json", "JsonHelper" }, 0, "'JsonSerializer' is used for JSON processing in C#."),
                        new Question("Which of the following is a valid lambda expression in C#?", new string[] { "x => x * 2", "(x) => return x * 2", "lambda(x) => x * 2", "func x => x * 2" }, 0, "'x => x * 2' is a valid lambda expression."),
                        new Question("Which LINQ method is used to filter elements from a collection?", new string[] { "Where()", "Select()", "OrderBy()", "GroupBy()" }, 0, "'Where()' is used to filter elements in LINQ."),
                        new Question("Which statement is used to explicitly exit a method?", new string[] { "exit", "break", "return", "stop" }, 2, "'return' is used to exit a method in C#."),
                        new Question("What is the purpose of the 'yield' keyword in C#?", new string[] { "Returns an iterator", "Stops execution", "Declares a variable", "None of the above" }, 0, "'yield' is used in iterator methods to return values one at a time."),
                        new Question("Which keyword is used to extend the functionality of an existing method?", new string[] { "extension", "add", "public", "this" }, 3, "'this' is used in extension methods."),
                        new Question("Which method is used to sort a List in C#?", new string[] { "Sort()", "OrderBy()", "Reverse()", "Arrange()" }, 0, "'Sort()' is used to sort a List in C#."),
                        new Question("What will 'Math.Round(4.6)' return in C#?", new string[] { "4", "5", "4.5", "Error" }, 1, "'Math.Round(4.6)' rounds to 5."),
                        new Question("What is the purpose of the 'Dispose()' method in C#?", new string[] { "Releases unmanaged resources", "Deletes a file", "Stops a thread", "None of the above" }, 0, "'Dispose()' is used to release unmanaged resources in C#."),
                        new Question("Which of the following is NOT a valid way to handle memory management in C#?", new string[] { "Using the 'Dispose' method", "Using garbage collection", "Manually deallocating memory", "Using 'using' blocks" }, 2, "C# does not support manual memory deallocation like C or C++."),
                        new Question("What is the purpose of the 'volatile' keyword in C#?", new string[] { "Ensures a variable is always read from memory", "Prevents a variable from being modified", "Declares a constant", "None of the above" }, 0, "'volatile' ensures a variable is always read from memory rather than from cache."),
                        new Question("Which of the following statements about C# events is true?", new string[] { "Events are based on delegates", "Events can have multiple subscribers", "Events are used in event-driven programming", "All of the above" }, 3, "C# events use delegates and support multiple subscribers in event-driven programming."),
                        new Question("Which of the following LINQ methods is used for sorting?", new string[] { "OrderBy()", "Where()", "Select()", "Filter()" }, 0, "'OrderBy()' is used to sort elements in LINQ."),
                        new Question("What will 'DateTime.Now.AddDays(5)' return?", new string[] { "The current date plus 5 days", "The current date minus 5 days", "The same date", "An error" }, 0, "'DateTime.Now.AddDays(5)' returns the date 5 days from now."),
                        new Question("Which class is used to handle background tasks in C#?", new string[] { "Task", "Thread", "Process", "BackgroundWorker" }, 3, "'BackgroundWorker' is specifically used for handling background tasks."),
                        new Question("Which of the following statements about 'async' and 'await' in C# is true?", new string[] { "'async' must be used with 'await'", "'await' can be used inside non-async methods", "'async' makes a method run in a separate thread", "'await' is used to pause execution until a task completes" }, 3, "'await' pauses execution until the asynchronous task completes."),
                        new Question("What will happen if a 'finally' block is used in a try-catch statement?", new string[] { "It always executes, regardless of an exception", "It executes only if an exception occurs", "It executes only if no exception occurs", "It prevents exceptions from occurring" }, 0, "'finally' always executes, whether an exception occurs or not."),
                        new Question("Which pattern is used to encapsulate object creation logic in C#?", new string[] { "Singleton", "Factory", "Observer", "Decorator" }, 1, "'Factory' is a design pattern that encapsulates object creation logic."),
                        new Question("Which of the following describes reflection in C#?", new string[] { "Examining and modifying metadata at runtime", "Reflecting an object to another class", "Copying object properties", "Creating a new instance dynamically" }, 0, "Reflection allows examining and modifying metadata at runtime."),

                    }}
                }
            },
            {
                "Python", new Dictionary<int, List<Question>> {
                    { 1, new List<Question> {
                        new Question("What is Python?", new string[] { "A snake", "A programming language", "An operating system", "A database" }, 1, "Python is a popular high-level programming language known for its readability and ease of use."),
                        new Question("Which keyword is used to define a function in Python?", new string[] { "func", "def", "function", "define" }, 1, "The 'def' keyword is used to define a function in Python."),
                        new Question("Which symbol is used for single-line comments in Python?", new string[] { "//", "#", "/* */", "--" }, 1, "The '#' symbol is used for single-line comments in Python."),
                        new Question("How do you declare a variable in Python?", new string[] { "int x = 10;", "x = 10;", "declare x = 10;", "var x = 10;" }, 1, "In Python, you declare a variable simply by assigning a value to it: 'x = 10'."),
                        new Question("Which function is used to output text in Python?", new string[] { "echo", "print", "write", "display" }, 1, "The 'print()' function is used to display output in Python."),
                        new Question("Which data type is used to store a sequence of characters?", new string[] { "int", "string", "list", "char" }, 1, "A string (str) is used to store a sequence of characters in Python."),
                        new Question("Which of the following is a valid list declaration in Python?", new string[] { "list = [1, 2, 3]", "list = (1, 2, 3)", "list = {1, 2, 3}", "list = <1, 2, 3>" }, 0, "Lists in Python are defined using square brackets: '[1, 2, 3]'."),
                        new Question("Which keyword is used to start a loop in Python?", new string[] { "for", "loop", "repeat", "iterate" }, 0, "'for' and 'while' are used for loops in Python."),
                        new Question("Which of these is NOT a valid Python data type?", new string[] { "int", "float", "double", "list" }, 2, "Python uses 'float' instead of 'double' for floating-point numbers."),
                        new Question("Which of the following is used to check a condition in Python?", new string[] { "if", "when", "check", "condition" }, 0, "The 'if' statement is used to check conditions in Python."),
                        new Question("Which function is used to take user input in Python?", new string[] { "input()", "read()", "get()", "scan()" }, 0, "'input()' is used to take user input in Python."),
                        new Question("Which operator is used for exponentiation in Python?", new string[] { "^", "**", "//", "exp" }, 1, "The '**' operator is used for exponentiation in Python."),
                        new Question("How do you create a comment in Python?", new string[] { "// This is a comment", "# This is a comment", "/* This is a comment */", "-- This is a comment" }, 1, "'#' is used for comments in Python."),
                        new Question("What is the default return value of a function that does not explicitly return a value?", new string[] { "0", "None", "False", "Undefined" }, 1, "Functions in Python return 'None' if no return statement is specified."),
                        new Question("Which keyword is used to define a loop that executes while a condition is true?", new string[] { "for", "while", "repeat", "loop" }, 1, "'while' is used for loops that run while a condition is true."),
                        new Question("Which of the following is used to assign a value to a variable in Python?", new string[] { "=", "==", ":=", "<-" }, 0, "The '=' operator is used to assign values to variables in Python."),
                        new Question("Which of the following is the correct way to create a list in Python?", new string[] { "list = {1, 2, 3}", "list = [1, 2, 3]", "list = (1, 2, 3)", "list = <1, 2, 3>" }, 1, "Lists in Python are defined using square brackets: '[1, 2, 3]'."),
                        new Question("Which of the following is used to import a module in Python?", new string[] { "import module", "include module", "use module", "require module" }, 0, "The 'import' keyword is used to import a module in Python."),
                        new Question("What does the 'len()' function do in Python?", new string[] { "Returns the length of a string or collection", "Converts a string to a list", "Returns the first element", "Checks if a value is in a list" }, 0, "'len()' returns the number of items in an object, such as a string or list."),
                        new Question("Which of these is a valid way to write a multi-line comment in Python?", new string[] { "# This is a comment", "/* This is a comment */", "'This is a comment'", "'''This is a comment'''" }, 3, "Multi-line comments in Python are written with triple single quotes or triple double quotes."),
                        new Question("How do you check the type of a variable in Python?", new string[] { "type(variable)", "checkType(variable)", "getType(variable)", "varType(variable)" }, 0, "The 'type()' function checks the type of a variable in Python."),
                        new Question("Which of the following will return True if a list contains the element '5'?", new string[] { "'5' in list", "list.contains(5)", "list.has(5)", "5 in list" }, 3, "In Python, '5 in list' checks if the list contains the element 5."),
                        new Question("Which of the following is used for integer division in Python?", new string[] { "/", "//", "%", "*" }, 1, "'//' is used for integer division, which returns the quotient without the remainder."),
                        new Question("What will 'print(2 ** 3)' output?", new string[] { "8", "6", "5", "3" }, 0, "'2 ** 3' computes 2 raised to the power of 3, which equals 8."),
                        new Question("Which of these is NOT a valid data type in Python?", new string[] { "int", "char", "float", "str" }, 1, "Python does not have a 'char' data type. It uses 'str' for strings."),

                    }},
                    { 2, new List<Question> {
                        new Question("How do you check the length of a string in Python?", new string[] { "length(str)", "size(str)", "len(str)", "count(str)" }, 2, "'len()' is used to get the length of a string in Python."),
                        new Question("Which keyword is used to handle exceptions in Python?", new string[] { "try", "catch", "except", "finally" }, 2, "'except' is used to handle exceptions in Python."),
                        new Question("Which method is used to convert a string to lowercase?", new string[] { "toLowerCase()", "lower()", "tolower()", "convertLower()" }, 1, "'lower()' is used to convert a string to lowercase in Python."),
                        new Question("How do you remove whitespace from the beginning and end of a string?", new string[] { "trim()", "strip()", "removeWhitespace()", "clean()" }, 1, "'strip()' removes leading and trailing whitespace from a string."),
                        new Question("What will '3 * 'abc'' return?", new string[] { "abcabcabc", "abc * 3", "Error", "None" }, 0, "Python allows string multiplication, so 'abc' * 3 results in 'abcabcabc'."),
                        new Question("Which of the following is used to add an element to a list?", new string[] { "push()", "insert()", "add()", "append()" }, 3, "'append()' adds an element to the end of a list."),
                        new Question("Which function is used to convert a string into an integer?", new string[] { "toInt()", "int()", "convertToInt()", "parseInt()" }, 1, "'int()' converts a string to an integer in Python."),
                        new Question("Which keyword is used to exit a loop?", new string[] { "break", "stop", "exit", "return" }, 0, "'break' is used to exit a loop in Python."),
                        new Question("What is the result of '10 // 3'?", new string[] { "3.33", "3", "4", "Error" }, 1, "'//' is the floor division operator, which returns 3."),
                        new Question("How do you access the first element of a list?", new string[] { "list[0]", "list.first()", "list[1]", "first(list)" }, 0, "Lists in Python are zero-indexed, so the first element is at index 0."),
                        new Question("What does the 'in' keyword do?", new string[] { "Checks if a value exists in a list or string", "Imports a module", "Defines a loop", "Declares a function" }, 0, "'in' is used to check for membership in a list or string."),
                        new Question("What is the output of 'bool([])'?", new string[] { "True", "False", "Error", "None" }, 1, "An empty list evaluates to False in Python."),
                        new Question("Which statement is used to define a class?", new string[] { "class", "define", "new", "struct" }, 0, "'class' is used to define a class in Python."),
                        new Question("Which of the following data structures is immutable?", new string[] { "list", "tuple", "set", "dictionary" }, 1, "'tuple' is immutable in Python."),
                        new Question("Which of the following functions returns the last element of a list?", new string[] { "list.pop()", "list[-1]", "list.last()", "list.tail()" }, 1, "'list[-1]' returns the last element of a list in Python."),
                        new Question("Which function is used to convert a list into a tuple?", new string[] { "convert()", "tuple()", "toTuple()", "listToTuple()" }, 1, "'tuple()' converts a list into a tuple."),
                        new Question("What is the correct way to check if a list is empty?", new string[] { "len(list) == 0", "list == None", "list.isEmpty()", "if list: pass" }, 0, "'len(list) == 0' checks if a list is empty."),
                        new Question("Which function returns the absolute value of a number?", new string[] { "abs()", "absolute()", "fabs()", "mod()" }, 0, "'abs()' returns the absolute value of a number."),
                        new Question("Which method is used to count occurrences of an element in a list?", new string[] { "list.count()", "list.find()", "list.index()", "list.search()" }, 0, "'count()' returns the number of times an element appears in a list."),
                        new Question("How do you remove the last element from a list?", new string[] { "list.pop()", "list.remove()", "list.delete()", "list[-1] = None" }, 0, "'pop()' removes and returns the last element of a list."),
                        new Question("Which of the following statements is used to skip an iteration in a loop?", new string[] { "pass", "break", "continue", "skip" }, 2, "'continue' skips the current iteration and moves to the next."),
                        new Question("How do you find the maximum value in a list?", new string[] { "max(list)", "list.max()", "highest(list)", "top(list)" }, 0, "'max()' returns the largest value in a list."),
                        new Question("What will 'sorted([3, 1, 4, 1, 5, 9])' return?", new string[] { "[9, 5, 4, 3, 1, 1]", "[1, 1, 3, 4, 5, 9]", "[3, 1, 4, 1, 5, 9]", "None" }, 1, "'sorted()' returns a new list sorted in ascending order."),
                        new Question("Which operator is used to check if two variables reference the same object?", new string[] { "==", "is", "equals", "===" }, 1, "'is' checks if two variables reference the same object."),
                        new Question("Which of the following is a valid way to create an empty dictionary?", new string[] { "dict()", "{}", "Both A and B", "None of the above" }, 2, "'{}' and 'dict()' both create an empty dictionary.")
                    }},
                    { 3, new List<Question> {
                        new Question("What will 'list(range(3))' return in Python?", new string[] { "[1, 2, 3]", "[0, 1, 2]", "[0, 1, 2, 3]", "range(3)" }, 1, "'range(3)' generates numbers from 0 to 2, so 'list(range(3))' returns '[0, 1, 2]'."),
                        new Question("What is the output of 'bool(0)'?", new string[] { "True", "False", "Error", "None" }, 1, "The integer 0 evaluates to False in a boolean context in Python."),
                        new Question("How do you access the last character of a string 's'?", new string[] { "s[-1]", "s[len(s)]", "s[last]", "s[-0]" }, 0, "'s[-1]' accesses the last character of a string."),
                        new Question("What does 'slicing' a list mean?", new string[] { "Copying a part of the list", "Deleting elements from a list", "Sorting a list", "Merging two lists" }, 0, "Slicing refers to extracting a portion of a list using 'list[start:end]'."),
                        new Question("Which statement correctly opens a file in write mode?", new string[] { "open('file.txt', 'r')", "open('file.txt', 'w')", "open('file.txt', 'a')", "open('file.txt')" }, 1, "'w' mode opens a file for writing, erasing existing content."),
                        new Question("How do you remove a specific element from a list by value?", new string[] { "del list[2]", "list.remove(value)", "list.pop(2)", "list.clear()" }, 1, "'remove(value)' removes the first occurrence of 'value' from a list."),
                        new Question("Which Python module is used for working with dates and times?", new string[] { "datetime", "time", "calendar", "date" }, 0, "The 'datetime' module is commonly used for date and time operations."),
                        new Question("What will 'set([1, 2, 2, 3])' return?", new string[] { "[1, 2, 2, 3]", "{1, 2, 2, 3}", "{1, 2, 3}", "Error" }, 2, "A set removes duplicate values, so '{1, 2, 3}' is returned."),
                        new Question("How do you check if a key exists in a dictionary?", new string[] { "dict.hasKey(key)", "'key' in dict", "dict.keyExists(key)", "dict.containsKey(key)" }, 1, "'key in dict' is used to check if a key exists."),
                        new Question("Which method adds an element to a set?", new string[] { "set.append()", "set.insert()", "set.add()", "set.push()" }, 2, "'add()' adds an element to a set."),
                        new Question("How do you iterate over a dictionary’s keys?", new string[] { "for key in dict.keys()", "for key in dict", "Both A and B", "None of the above" }, 2, "Both 'for key in dict.keys()' and 'for key in dict' iterate over keys."),
                        new Question("What will 'list((1, 2, 3))' return?", new string[] { "[1, 2, 3]", "(1, 2, 3)", "{1, 2, 3}", "Error" }, 0, "'list()' converts a tuple to a list."),
                        new Question("How do you create an empty set in Python?", new string[] { "set()", "{} ", "[]", "emptySet()" }, 0, "'set()' creates an empty set, while '{}' creates an empty dictionary."),
                        new Question("Which method is used to sort a list in-place?", new string[] { "sort()", "sorted()", "order()", "arrange()" }, 0, "'sort()' sorts a list in-place."),
                        new Question("What is the correct way to declare a set in Python?", new string[] { "set = []", "set = {}", "set = set()", "set = ()" }, 1, "Sets are declared using curly braces or the 'set()' constructor."),
                        new Question("How do you join elements of a list into a string?", new string[] { "str.join()", "list.join()", "join(str)", "','.join()" }, 3, "'','.join()' joins list elements into a single string with commas."),
                        new Question("Which function is used to find the index of an element in a list?", new string[] { "index()", "find()", "locate()", "position()" }, 0, "'index()' returns the index of the first occurrence of an element in a list."),
                        new Question("How can you check if a list contains a specific element?", new string[] { "list.contains()", "'element' in list", "list.has()", "element.in(list)" }, 1, "'in' is used to check if an element exists in a list."),
                        new Question("Which operator is used to check if two variables refer to the same object?", new string[] { "==", "is", "equals", "===" }, 1, "'is' checks if two variables refer to the same object."),
                        new Question("How do you remove duplicates from a list in Python?", new string[] { "list.removeDuplicates()", "set(list)", "unique(list)", "list.distinct()" }, 1, "Converting a list to a set removes duplicates."),
                        new Question("What will 'list([1, 2, 3, 4, 5])[::-1]' return?", new string[] { "[5, 4, 3, 2, 1]", "[1, 2, 3, 4, 5]", "[1, 3, 5, 4, 2]", "Error" }, 0, "The '[::-1]' reverses the list."),
                        new Question("What does 'filter(None, list)' do in Python?", new string[] { "Filters out None values from a list", "Removes even numbers", "Sorts the list", "Adds None to the list" }, 0, "'filter(None, list)' removes all 'None' values from a list."),
                        new Question("Which method is used to add a key-value pair to a dictionary?", new string[] { "dict.add()", "dict.insert()", "dict.put()", "dict[key] = value" }, 3, "You can add a key-value pair to a dictionary with 'dict[key] = value'."),
                        new Question("How do you handle multiple exceptions in a try-except block?", new string[] { "try-except-finally", "except (Error1, Error2) as e:", "except Error1 or Error2", "try-except in sequence" }, 1, "You can handle multiple exceptions in a single block using 'except (Error1, Error2) as e:'."),

                    }},
                    { 4, new List<Question> {
                        new Question("Which of the following is a correct way to define a function?", new string[] { "func myFunction():", "define myFunction():", "def myFunction():", "function myFunction():" }, 2, "'def myFunction():' is the correct syntax for defining a function."),
                        new Question("What is the purpose of the 'zip()' function?", new string[] { "To combine multiple iterables into tuples", "To compress a file", "To sort a list", "To concatenate two strings" }, 0, "'zip()' pairs elements from multiple iterables into tuples."),
                        new Question("How do you handle an exception in Python?", new string[] { "try-except", "catch-throw", "error-handler", "handle() function" }, 0, "'try-except' is used for exception handling in Python."),
                        new Question("What does 'enumerate()' do?", new string[] { "Adds an index to an iterable", "Sorts a list", "Finds the count of elements", "Removes duplicates" }, 0, "'enumerate()' adds an index to an iterable in a loop."),
                        new Question("Which function is used to read a file line by line?", new string[] { "read()", "readlines()", "readline()", "fetch()" }, 2, "'readline()' reads a file line by line."),
                        new Question("Which of the following removes all elements from a list?", new string[] { "list.removeAll()", "list.clear()", "list.delete()", "list.pop()" }, 1, "'clear()' removes all elements from a list."),
                        new Question("What is the output of 'print(2 ** 3)'?", new string[] { "6", "8", "9", "Error" }, 1, "'2 ** 3' calculates 2 raised to the power of 3, which is 8."),
                        new Question("Which statement is true about Python classes?", new string[] { "They cannot have constructors", "They support inheritance", "They must always have methods", "They cannot contain variables" }, 1, "Python classes support inheritance."),
                        new Question("Which method is used to remove and return the last item of a list?", new string[] { "list.remove()", "list.pop()", "list.delete()", "list.extract()" }, 1, "'pop()' removes and returns the last item."),
                        new Question("What will 'my_dict.get('key', 'default')' return if 'key' is not present?", new string[] { "None", "'default'", "Error", "An empty dictionary" }, 1, "'get()' returns 'default' if the key is not found."),
                        new Question("How do you define a class method in Python?", new string[] { "@classmethod", "@static", "@method", "def classmethod()" }, 0, "'@classmethod' defines a class method."),
                        new Question("Which of these is NOT a valid Python function name?", new string[] { "_my_func", "2nd_function", "myFunction", "func_name" }, 1, "Function names cannot start with a number."),
                        new Question("What is the difference between 'is' and '=='?", new string[] { "'is' checks identity, '==' checks value", "'==' checks identity, 'is' checks value", "Both are the same", "None of the above" }, 0, "'is' checks if two objects are the same instance, '==' checks if values are equal."),
                        new Question("What does 'continue' do in a loop?", new string[] { "Stops the loop", "Skips the current iteration", "Exits the program", "Restarts the loop" }, 1, "'continue' skips the current iteration and moves to the next."),
                        new Question("How do you create an infinite loop in Python?", new string[] { "while True:", "for i in range(infinity):", "loop forever()", "while 1:" }, 0, "'while True:' creates an infinite loop."),
                        new Question("Which method is used to return a shallow copy of a dictionary?", new string[] { "copy()", "clone()", "duplicate()", "replicate()" }, 0, "'copy()' creates a shallow copy of a dictionary."),
                        new Question("What does 'super().__init__()' do in Python?", new string[] { "Calls the parent class's constructor", "Creates a new class", "Initializes an object", "Stops the execution of a class" }, 0, "'super().__init__()' calls the constructor of the parent class."),
                        new Question("How do you define a static method in a Python class?", new string[] { "def staticmethod()", "def static_method()", "@staticmethod", "def method_static()" }, 2, "'@staticmethod' is used to define a static method."),
                        new Question("Which of the following is the correct syntax to create a generator function?", new string[] { "def gen(): yield x", "def gen(): return x", "def gen(x): return yield", "def gen: yield x" }, 0, "A generator function uses 'yield' to return values one at a time."),
                        new Question("What does 'map()' function do?", new string[] { "Applies a function to each item in an iterable", "Maps a value to a variable", "Changes values in a dictionary", "Duplicates elements in a list" }, 0, "'map()' applies a function to each item in an iterable and returns an iterator."),
                        new Question("Which of these will create a new dictionary with updated values?", new string[] { "dict.update()", "dict.modify()", "dict.merge()", "dict.add()" }, 0, "'update()' modifies a dictionary in-place by updating its keys and values."),
                        new Question("How do you create a class that cannot be instantiated directly?", new string[] { "class MyClass:", "class MyClass(ABC):", "class MyClass(abstract):", "class MyClass(classmethod):" }, 1, "To create an abstract class, you use 'ABC' and 'abstractmethod'."),
                        new Question("What will be the output of 'str(3.14) == '3.14''?", new string[] { "True", "False", "Error", "None" }, 0, "Converting a float to string will result in 'True'."),
                        new Question("Which function is used to split a string into a list?", new string[] { "split()", "splitList()", "divide()", "break()" }, 0, "'split()' divides a string into a list based on a delimiter."),
                        new Question("Which of these methods is used to remove an item by its index in a list?", new string[] { "list.remove()", "list.pop()", "list.delete()", "list.removeByIndex()" }, 1, "'pop()' removes an item at a specified index and returns it."),


                    }}
                }
            }
        };
    }

    // Method to get questions based on the selected language and level
    public List<Question> GetQuestionsForLanguageAndLevel(string language, int level)
    {
        if (questionsByLanguageAndLevel.ContainsKey(language) && questionsByLanguageAndLevel[language].ContainsKey(level))
        {
            return questionsByLanguageAndLevel[language][level]; // Return questions for the selected language and level
        }
        else
        {
            Debug.LogError($"No questions found for language {language} and level {level}");
            return new List<Question>(); // Return empty list if no questions are found
        }
    }
}
// Define a class to represent a question with answers and correct answer index
[System.Serializable]
public class Question
{
    public string questionText;
    public string[] possibleAnswers;
    public int correctAnswerIndex;
    public string explanation; // Explanation for the correct answer

    public Question(string questionText, string[] possibleAnswers, int correctAnswerIndex, string explanation)
    {
        this.questionText = questionText;
        this.possibleAnswers = possibleAnswers;
        this.correctAnswerIndex = correctAnswerIndex;
        this.explanation = explanation;
    }
}
