using System.Collections.Generic;
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
                "HTML", new Dictionary<int, List<Question>> {
                    { 1, new List<Question> {
                        new Question("What does HTML stand for?", new string[] { "Hyper Text Markup Language", "High Text Markup Language", "Hyper Link Markup Language", "None of the above" }, 0),
                        new Question("What tag is used for links?", new string[] { "<link>", "<a>", "<url>", "<href>" }, 1),
                        new Question("Which tag is used to create a form?", new string[] { "<form>", "<input>", "<button>", "<div>" }, 0),
                        new Question("What does the <head> tag contain?", new string[] { "Metadata", "Content", "Links", "Images" }, 0),
                        new Question("What is the correct syntax for embedding JavaScript?", new string[] { "<js src='script.js'>", "<script src='script.js'>", "<javascript src='script.js'>", "<js>script.js</js>" }, 1),
                        new Question("What is the correct way to add a comment in HTML?", new string[] { "<!-- This is a comment -->", "// This is a comment", "/* This is a comment */", "<comment>This is a comment</comment>" }, 0),
                        new Question("Which of the following tags is used to display images?", new string[] { "<image>", "<img>", "<picture>", "<src>" }, 1),
                        new Question("Which HTML tag is used for a line break?", new string[] { "<br>", "<hr>", "<line>", "<break>" }, 0),
                        new Question("What does the <body> tag represent?", new string[] { "The main content of the document", "Metadata about the document", "The header section", "None of the above" }, 0),
                        new Question("Which HTML tag is used for defining a list?", new string[] { "<ul>", "<ol>", "<list>", "<dl>" }, 0),
                        new Question("Which of the following is used to make text italic in HTML?", new string[] { "<i>", "<em>", "<strong>", "<b>" }, 0),
                        new Question("Which HTML element is used to define an unordered list?", new string[] { "<ul>", "<ol>", "<li>", "<dl>" }, 0),
                        new Question("Which tag is used to define a section in HTML?", new string[] { "<section>", "<div>", "<header>", "<article>" }, 0),
                        new Question("Which attribute is used to specify an image's alternate text?", new string[] { "alt", "title", "src", "longdesc" }, 0),
                        new Question("Which of the following tags is used for a block-level element?", new string[] { "<div>", "<span>", "<a>", "<img>" }, 0),
                        new Question("How do you create a comment in HTML?", new string[] { "<!-- comment -->", "// comment", "/* comment */", "<comment>comment</comment>" }, 0),
                        new Question("Which tag is used to define a header in HTML?", new string[] { "<header>", "<h1>", "<head>", "<title>" }, 0),
                        new Question("Which attribute is used to specify the target for a link in HTML?", new string[] { "target", "href", "action", "rel" }, 0),
                        new Question("What is the default display property for a <div> element?", new string[] { "block", "inline", "inline-block", "none" }, 0),
                    }},
                    { 2, new List<Question> {
                        new Question("What is the purpose of the <div> tag?", new string[] { "To divide sections", "To display images", "To make text bold", "None of the above" }, 0),
                        new Question("What tag is used to define an HTML document?", new string[] { "<html>", "<document>", "<body>", "<head>" }, 0),
                        new Question("How do you add a comment in HTML?", new string[] { "<!-- Comment -->", "// Comment", "/* Comment */", "//Comment" }, 0),
                        new Question("Which of the following is used to insert an image?", new string[] { "<image>", "<img>", "<picture>", "<src>" }, 1),
                        new Question("Which HTML element is used to create a form?", new string[] { "<input>", "<form>", "<button>", "<select>" }, 1),
                        new Question("How do you make text bold in HTML?", new string[] { "<strong>", "<bold>", "<b>", "<em>" }, 0),
                        new Question("What does the <meta> tag define?", new string[] { "Metadata about the document", "Page content", "Links", "Images" }, 0),
                        new Question("Which tag is used to create a hyperlink?", new string[] { "<a>", "<link>", "<href>", "<url>" }, 0),
                        new Question("Which tag is used for a heading?", new string[] { "<h1>", "<title>", "<head>", "<header>" }, 0),
                        new Question("Which tag is used to define a table in HTML?", new string[] { "<table>", "<tr>", "<td>", "<thead>" }, 0),
                        new Question("What is the purpose of the <head> tag?", new string[] { "To define metadata", "To define the body content", "To link external resources", "To define the footer" }, 0),
                        new Question("Which tag is used to add a background color in HTML?", new string[] { "<bgcolor>", "<style>", "<div style='background-color: color;'>", "<background>" }, 2),
                        new Question("Which HTML tag is used to create a button?", new string[] { "<button>", "<a>", "<input>", "<form>" }, 0),
                        new Question("What is the correct tag for defining the main content area in HTML5?", new string[] { "<main>", "<section>", "<div>", "<content>" }, 0),
                        new Question("What does the <iframe> tag allow in HTML?", new string[] { "To embed another HTML page", "To create a link", "To add an image", "To create an input form" }, 0),
                        new Question("Which HTML element is used for embedding audio?", new string[] { "<audio>", "<media>", "<sound>", "<file>" }, 0),
                        new Question("Which tag is used to create a table cell?", new string[] { "<td>", "<tr>", "<th>", "<table>" }, 0),
                        new Question("What does the <header> tag represent in HTML5?", new string[] { "The header content of a page", "The main content area", "The footer section", "The sidebar" }, 0),
                        new Question("Which tag is used to define a blockquote in HTML?", new string[] { "<blockquote>", "<quote>", "<p>", "<bq>" }, 0),
                        new Question("How do you add external CSS to a webpage in HTML?", new string[] { "<link rel='stylesheet' href='style.css'>", "<style href='style.css'>", "<css src='style.css'>", "<link src='style.css'>"}, 0)
                    }},
                        { 3, new List<Question> {
                            new Question("What is the purpose of the <meta> tag in HTML?", new string[] { "Define metadata about the document", "Define page content", "Add links to other pages", "Display a message" }, 0),
                            new Question("What is the correct syntax to link an external CSS file?", new string[] { "<link src=\"styles.css\">", "<style src=\"styles.css\">", "<link href=\"styles.css\" rel=\"stylesheet\">", "<css src=\"styles.css\">" }, 2),
                            new Question("Which HTML attribute specifies the character encoding for the document?", new string[] { "charset", "encoding", "meta", "utf-8" }, 0),
                            new Question("Which tag is used to create a hyperlink?", new string[] { "<link>", "<a>", "<url>", "<href>" }, 1),
                            new Question("What does the <head> tag typically contain?", new string[] { "Links and metadata", "Body content", "Navigation", "Text content" }, 0),
                            new Question("Which tag is used for embedding a YouTube video?", new string[] { "<video>", "<iframe>", "<embed>", "<youtube>" }, 1),
                            new Question("Which tag is used to create a navigation bar?", new string[] { "<nav>", "<header>", "<footer>", "<menu>" }, 0),
                            new Question("How do you add a background image in HTML?", new string[] { "<background>image.jpg</background>", "<img src='image.jpg'>", "<div style='background-image: url(image.jpg);'>", "<image src='image.jpg'>" }, 2),
                            new Question("Which tag is used to group inline elements?", new string[] { "<span>", "<div>", "<section>", "<header>" }, 0),
                            new Question("How do you define a hyperlink in HTML?", new string[] { "<a href='link'>", "<link href='link'>", "<url>link</url>", "<href='link'>" }, 0),
                            new Question("Which tag is used to define the title of a document?", new string[] { "<title>", "<header>", "<meta>", "<head>" }, 0),
                            new Question("What is the correct tag for defining an image?", new string[] { "<img>", "<image>", "<src>", "<picture>" }, 0),
                            new Question("Which tag is used to define the footer in HTML5?", new string[] { "<footer>", "<end>", "<bottom>", "<section>" }, 0),
                            new Question("How do you make text bold in HTML?", new string[] { "<strong>", "<bold>", "<b>", "<em>" }, 0),
                            new Question("Which HTML tag is used for defining a column group in a table?", new string[] { "<colgroup>", "<thead>", "<col>", "<table>" }, 0),
                            new Question("Which tag is used to create a dropdown list in HTML?", new string[] { "<select>", "<option>", "<input>", "<dropdown>" }, 0),
                            new Question("What does the <article> tag represent in HTML5?", new string[] { "A section of independent content", "The header of the page", "The footer of the page", "The body of the document" }, 0)
                        }},
                         { 4, new List<Question> {
                            new Question("What is the purpose of the <link> tag in HTML?", new string[] { "To define metadata", "To link to external files", "To create a hyperlink", "To display images" }, 1),
                            new Question("What is the correct syntax for embedding a video in HTML?", new string[] { "<video src='video.mp4'>", "<embed src='video.mp4'>", "<video href='video.mp4'>", "<iframe src='video.mp4'>" }, 0),
                            new Question("Which HTML element is used for navigation links?", new string[] { "<nav>", "<links>", "<header>", "<menu>" }, 0),
                            new Question("Which attribute is used to define the source of an image?", new string[] { "href", "src", "alt", "link" }, 1),
                            new Question("Which tag is used to create an ordered list?", new string[] { "<ol>", "<ul>", "<li>", "<dl>" }, 0),
                            new Question("Which attribute is used to specify the width of an image?", new string[] { "height", "width", "size", "img" }, 1),
                            new Question("What is the correct syntax for creating an external link in HTML?", new string[] { "<a href='http://example.com'>Link</a>", "<link href='http://example.com'>Link</link>", "<a src='http://example.com'>Link</a>", "<url href='http://example.com'>Link</url>" }, 0),
                            new Question("What is the purpose of the <footer> tag in HTML?", new string[] { "To define the footer of a document", "To define metadata", "To create a navigation bar", "To insert a header" }, 0),
                            new Question("What is the correct tag to create a form in HTML?", new string[] { "<form>", "<input>", "<select>", "<textarea>" }, 0),
                            new Question("Which of the following tags is used to define a table row?", new string[] { "<tr>", "<td>", "<th>", "<thead>" }, 0),
                            new Question("How do you define a class attribute in HTML?", new string[] { "<div class='classname'>", "<div id='classname'>", "<class='classname'>", "<div name='classname'>" }, 0),
                            new Question("Which tag is used to create a table header?", new string[] { "<th>", "<thead>", "<header>", "<title>" }, 0),
                            new Question("Which tag is used to define an abbreviation in HTML?", new string[] { "<abbr>", "<acronym>", "<abbreviation>", "<short>" }, 0),
                            new Question("How do you define a link to an email in HTML?", new string[] { "<a href='mailto:email@example.com'>Email</a>", "<link href='mailto:email@example.com'>Email</link>", "<email href='mailto:email@example.com'>Email</email>", "<a mailto='email@example.com'>Email</a>" }, 0),
                            new Question("What does the <mark> tag represent in HTML?", new string[] { "Highlighted text", "Background color", "Links", "Text decoration" }, 0),
                            new Question("What is the correct tag for defining the language of the document?", new string[] { "<html lang='en'>", "<lang='en'>", "<document lang='en'>", "<language='en'>" }, 0),
                            new Question("Which of the following tags is used to define a definition list?", new string[] { "<dl>", "<ul>", "<ol>", "<list>" }, 0)
                        }}

                }
            },
           {
                "Java", new Dictionary<int, List<Question>> {
                        { 1, new List<Question> {
                            new Question("What is Java?", new string[] { "A programming language", "A framework", "A text editor", "None of the above" }, 0),
                            new Question("What does JVM stand for?", new string[] { "Java Variable Memory", "Java Virtual Machine", "Java Versatile Model", "None of the above" }, 1),
                            new Question("Which keyword is used to create a class in Java?", new string[] { "class", "new", "create", "object" }, 0),
                            new Question("Which of the following is a primitive data type in Java?", new string[] { "int", "String", "Object", "Array" }, 0),
                            new Question("Which method is used to output text to the console in Java?", new string[] { "println()", "print()", "display()", "log()" }, 0),
                            new Question("What is the default value of an object reference in Java?", new string[] { "null", "undefined", "0", "false" }, 0),
                            new Question("Which keyword is used to define a method in Java?", new string[] { "method", "function", "def", "public" }, 3),
                            new Question("What does 'public' mean in Java?", new string[] { "Accessible by all classes", "Accessible only within the same package", "Private", "Protected" }, 0),
                            new Question("Which operator is used to compare two objects in Java?", new string[] { "==", "equals()", "compare()", "equalsIgnoreCase()" }, 1),
                            new Question("What is an array in Java?", new string[] { "A collection of elements of the same type", "A method", "A class", "A variable" }, 0),
                            new Question("What is the default value of a boolean in Java?", new string[] { "true", "false", "null", "0" }, 1),
                            new Question("Which of the following is the correct way to declare a method in Java?", new string[] { "public void myMethod()", "void public myMethod()", "public myMethod()", "None of the above" }, 0),
                            new Question("What is the default value of an integer in Java?", new string[] { "0", "null", "undefined", "1" }, 0),
                            new Question("Which of the following is the correct syntax for a constructor?", new string[] { "public MyClass() {}", "MyClass() {}", "constructor MyClass() {}", "None of the above" }, 0),
                            new Question("What does 'static' mean in Java?", new string[] { "A method or variable belongs to the class, not an instance", "Defines a class", "A method that doesn't return anything", "None of the above" }, 0),
                            new Question("What is the purpose of the 'final' keyword in Java?", new string[] { "Makes a variable constant", "Indicates a method can't be overridden", "Indicates a class can't be subclassed", "All of the above" }, 3),
                            new Question("What does the 'super' keyword do in Java?", new string[] { "Refers to the parent class", "Refers to the current class", "Refers to the current method", "None of the above" }, 0)
                        }},
                        { 2, new List<Question> {
                            new Question("What is the purpose of a constructor in Java?", new string[] { "Initialize objects", "Store data", "Create variables", "None of the above" }, 0),
                            new Question("Which of the following is not a Java primitive data type?", new string[] { "int", "char", "boolean", "object" }, 3),
                            new Question("What does the 'static' keyword do in Java?", new string[] { "Makes a method or variable shared among all instances of a class", "Declares a method", "Declares an object", "None of the above" }, 0),
                            new Question("Which of the following is a valid method signature in Java?", new string[] { "public void method()", "method public void()", "void method public()", "None of the above" }, 0),
                            new Question("What is the default value of a boolean in Java?", new string[] { "true", "false", "null", "0" }, 1),
                            new Question("What does the 'super' keyword do in Java?", new string[] { "Refers to the parent class", "Refers to the current object", "Refers to a static method", "None of the above" }, 0),
                            new Question("What does the 'this' keyword refer to in Java?", new string[] { "Refers to the current object", "Refers to the superclass", "Refers to a variable", "None of the above" }, 0),
                            new Question("What is the default value of a local variable in Java?", new string[] { "null", "0", "undefined", "Not initialized" }, 3),
                            new Question("What is the correct syntax for an if statement in Java?", new string[] { "if (condition) {}", "if condition {}", "if condition {}", "if {condition} {}" }, 0),
                            new Question("Which method is used to get the length of an array in Java?", new string[] { "length()", "size()", "getLength()", "arrayLength()" }, 0),
                            new Question("What is the purpose of the 'transient' keyword in Java?", new string[] { "Indicates that a field should not be serialized", "Indicates that a method cannot be overridden", "Makes a field static", "None of the above" }, 0),
                            new Question("What does the 'volatile' keyword do in Java?", new string[] { "Indicates that a field can be modified by multiple threads", "Makes a field static", "Prevents a field from being modified", "None of the above" }, 0),
                            new Question("What is the superclass of all classes in Java?", new string[] { "Object", "String", "Class", "Integer" }, 0),
                            new Question("What is the difference between == and .equals() in Java?", new string[] { "== compares references, .equals() compares values", "== compares values, .equals() compares references", "Both compare values", "Both compare references" }, 0),
                            new Question("Which class is used to create a thread in Java?", new string[] { "Thread", "Runnable", "Object", "Executor" }, 0),
                            new Question("What is the correct way to handle exceptions in Java?", new string[] { "try-catch block", "throw-try block", "catch-finally block", "None of the above" }, 0)
                        }},
                        { 3, new List<Question> {
                            new Question("What is the default value of an integer in Java?", new string[] { "0", "null", "undefined", "1" }, 0),
                            new Question("Which keyword is used to prevent a method from being overridden in Java?", new string[] { "final", "static", "private", "public" }, 0),
                            new Question("What does the 'super' keyword refer to in Java?", new string[] { "The parent class", "The current object", "A static method", "A constructor" }, 0),
                            new Question("What is the purpose of the 'this' keyword in Java?", new string[] { "Refers to the current object", "Refers to the superclass", "Refers to a variable", "None of the above" }, 0),
                            new Question("Which of the following is a valid constructor in Java?", new string[] { "public MyClass() {}", "MyClass() {}", "MyClass:() {}", "constructor MyClass() {}" }, 0),
                            new Question("What does the 'instanceof' keyword do in Java?", new string[] { "Checks if an object is an instance of a class", "Creates a new instance of a class", "Declares a new object", "None of the above" }, 0),
                            new Question("What is the difference between == and .equals() in Java?", new string[] { "== compares object references, .equals() compares object values", "== compares object values, .equals() compares object references", "Both compare values", "Both compare references" }, 0),
                            new Question("What does the 'break' statement do in Java?", new string[] { "Exits the loop or switch statement", "Ends the program", "Returns a value", "None of the above" }, 0),
                            new Question("What is the correct syntax for a for-each loop in Java?", new string[] { "for (type var : collection) {}", "for (type var in collection) {}", "for-each (var : collection) {}", "foreach (var : collection) {}" }, 0),
                            new Question("Which of the following is an immutable class in Java?", new string[] { "String", "ArrayList", "HashMap", "StringBuilder" }, 0),
                            new Question("What is the purpose of the 'transient' keyword in Java?", new string[] { "Indicates that a field should not be serialized", "Prevents modification of a variable", "Marks a field as volatile", "None of the above" }, 0),
                            new Question("What is the correct way to create a new thread in Java?", new string[] { "By extending the Thread class or implementing the Runnable interface", "By using a method", "By using a static class", "None of the above" }, 0),
                            new Question("Which of the following is used for synchronization in Java?", new string[] { "synchronized keyword", "volatile keyword", "final keyword", "None of the above" }, 0),
                            new Question("What does the 'instanceof' operator return in Java?", new string[] { "True or false", "An instance of the object", "The class of the object", "The type of the object" }, 0),
                            new Question("What happens when a return statement is executed in a method?", new string[] { "Exits the method immediately", "Returns the value to the caller", "Stops the program", "None of the above" }, 0)
                        }},
                        { 4, new List<Question> {
                            new Question("What is the default value of an integer in Java?", new string[] { "0", "null", "undefined", "1" }, 0),
                            new Question("Which keyword is used to prevent a method from being overridden in Java?", new string[] { "final", "static", "private", "public" }, 0),
                            new Question("What does the 'super' keyword refer to in Java?", new string[] { "The parent class", "The current object", "A static method", "A constructor" }, 0),
                            new Question("What is the purpose of the 'this' keyword in Java?", new string[] { "Refers to the current object", "Refers to the superclass", "Refers to a variable", "None of the above" }, 0),
                            new Question("Which of the following is a valid constructor in Java?", new string[] { "public MyClass() {}", "MyClass() {}", "MyClass:() {}", "constructor MyClass() {}" }, 0),
                            new Question("What does the 'instanceof' keyword do in Java?", new string[] { "Checks if an object is an instance of a class", "Creates a new instance of a class", "Declares a new object", "None of the above" }, 0),
                            new Question("What is the difference between == and .equals() in Java?", new string[] { "== compares object references, .equals() compares object values", "== compares object values, .equals() compares object references", "Both compare values", "Both compare references" }, 0),
                            new Question("What does the 'break' statement do in Java?", new string[] { "Exits the loop or switch statement", "Ends the program", "Returns a value", "None of the above" }, 0),
                            new Question("What is the correct syntax for a for-each loop in Java?", new string[] { "for (type var : collection) {}", "for (type var in collection) {}", "for-each (var : collection) {}", "foreach (var : collection) {}" }, 0),
                            new Question("Which of the following is an immutable class in Java?", new string[] { "String", "ArrayList", "HashMap", "StringBuilder" }, 0),
                            new Question("What is the purpose of the 'transient' keyword in Java?", new string[] { "Indicates that a field should not be serialized", "Makes a method static", "Prevents a field from being modified", "None of the above" }, 0),
                            new Question("What does the 'volatile' keyword do in Java?", new string[] { "Indicates that a field can be modified by multiple threads", "Prevents a field from being modified", "Indicates that a method is synchronized", "None of the above" }, 0),
                            new Question("Which class is the superclass of all classes in Java?", new string[] { "Object", "String", "Integer", "Class" }, 0),
                            new Question("What is the purpose of the 'final' keyword in Java?", new string[] { "Prevents modification of a class, method, or variable", "Defines the maximum value of a variable", "Declares a variable as constant", "None of the above" }, 0),
                            new Question("Which method is used to compare two strings in Java?", new string[] { "equals()", "compare()", "compareTo()", "isEqual()" }, 0),
                            new Question("What is the output of the following code? System.out.println(2 + 2 + '2');", new string[] { "22", "4", "42", "Error" }, 0),
                            new Question("Which of the following is true about the 'hashCode()' method in Java?", new string[] { "It returns a hash value for an object", "It is used to compare objects", "It is called when objects are printed", "None of the above" }, 0)
                        }}
                    }

            },
            {
                   "C#", new Dictionary<int, List<Question>> {
                        { 1, new List<Question> {
                            new Question("What is C#?", new string[] { "A programming language", "A software framework", "A database", "None of the above" }, 0),
                            new Question("Which of the following is used to create a new object in C#?", new string[] { "new", "create", "init", "build" }, 0),
                            new Question("Which method is used to compare two strings in C#?", new string[] { "Compare()", "Equals()", "CompareTo()", "Match()" }, 2),
                            new Question("Which keyword is used to define an interface in C#?", new string[] { "interface", "implements", "abstract", "class" }, 0),
                            new Question("Which of the following is not a valid C# loop?", new string[] { "for", "foreach", "repeat", "while" }, 2),
                            new Question("Which of the following is the correct syntax to declare an array in C#?", new string[] { "int[] arr;", "arr[] int;", "int arr[];", "new int[] arr;" }, 0),
                            new Question("What does the 'readonly' keyword mean in C#?", new string[] { "Value cannot be changed after initialization", "Value can be changed at runtime", "Constant value", "Used for constant expressions only" }, 0),
                            new Question("What type of collection is a 'List' in C#?", new string[] { "Generic collection", "Non-generic collection", "Array", "Queue" }, 0),
                            new Question("Which of the following is used to handle errors in C#?", new string[] { "try-catch", "error-catch", "error-try", "catch-try" }, 0),
                            new Question("Which of the following is a value type in C#?", new string[] { "int", "string", "object", "class" }, 0),
                            new Question("What is the result of '5 / 2' in C#?", new string[] { "2", "2.5", "3", "0" }, 0),
                            new Question("What is a 'delegate' in C#?", new string[] { "A reference type for method references", "A loop structure", "A variable type", "A class type" }, 0),
                            new Question("Which keyword is used to declare a constant in C#?", new string[] { "const", "static", "immutable", "final" }, 0),
                            new Question("What is the default value of a boolean variable in C#?", new string[] { "true", "false", "null", "0" }, 1),
                            new Question("What is the correct syntax for a switch statement in C#?", new string[] { "switch(variable) { case value: break; }", "switch (variable): { case value: break; }", "switch: variable { case value: break; }", "switch [variable] { case value: break; }" }, 0),
                            new Question("What is the result of '2 * 3 + 4' in C#?", new string[] { "10", "12", "8", "6" }, 0),
                            new Question("Which of the following types is used for nullable value types in C#?", new string[] { "Nullable<T>", "T?", "Null<T>", "Option<T>" }, 1),
                            new Question("Which of the following methods is used to convert a string to an integer in C#?", new string[] { "ToInt()", "Parse()", "ConvertToInt()", "ToInteger()" }, 1),
                            new Question("Which keyword is used to create a subclass in C#?", new string[] { "inherits", "extends", "base", ":", "None of the above" }, 3),
                            new Question("Which of the following is not a valid access modifier in C#?", new string[] { "public", "private", "protected", "internal", "exclusive" }, 4),
                            new Question("Which of the following is used to define a class in C#?", new string[] { "class", "def", "struct", "object" }, 0)
                        }},
                        { 2, new List<Question> {
                            new Question("What is the difference between '==' and 'Equals()' in C#?", new string[] { "Both compare values", "== compares references, Equals() compares values", "== compares values, Equals() compares references", "== is used for strings only" }, 0),
                            new Question("Which of the following is used for exception handling in C#?", new string[] { "try-catch", "error-catch", "throw-catch", "try-except" }, 0),
                            new Question("Which method is used to concatenate two strings in C#?", new string[] { "Concat()", "Join()", "Add()", "Append()" }, 0),
                            new Question("Which of the following is used to implement an interface in C#?", new string[] { "implements", "inherits", "abstract", "class" }, 0),
                            new Question("Which of the following methods is used to check if a string contains a substring?", new string[] { "contains()", "indexOf()", "Contains()", "Substring()" }, 2),
                            new Question("What is the purpose of the 'ref' keyword in C#?", new string[] { "Passes the reference of a variable", "Defines a constant", "Makes a variable read-only", "Marks a variable as nullable" }, 0),
                            new Question("What does the 'base' keyword do in C#?", new string[] { "Refers to the base class", "Refers to the current object", "Used to define a base class", "None of the above" }, 0),
                            new Question("What is the default value of a reference type variable in C#?", new string[] { "null", "undefined", "0", "false" }, 0),
                            new Question("What does the 'is' keyword do in C#?", new string[] { "Checks the type of an object", "Creates a new instance of an object", "Declares a variable", "Checks if a variable is null" }, 0),
                            new Question("Which of the following is not a valid collection in C#?", new string[] { "List", "Array", "Queue", "LinkedList", "Vector" }, 4),
                            new Question("What is a 'struct' in C#?", new string[] { "A value type that can hold multiple values", "A reference type", "A class type", "None of the above" }, 0),
                            new Question("Which method is used to convert a string to uppercase in C#?", new string[] { "ToUpper()", "Upper()", "ToCapital()", "UpperCase()" }, 0),
                            new Question("What is a 'delegate' used for in C#?", new string[] { "To pass methods as parameters", "To define a method", "To execute a loop", "To handle exceptions" }, 0),
                            new Question("What is the purpose of the 'yield' keyword in C#?", new string[] { "Returns an element in a collection", "Pauses the execution of a method", "Defines a loop", "Creates a new object" }, 0),
                            new Question("What does the 'continue' keyword do in C#?", new string[] { "Skips the current iteration of a loop", "Exits the loop", "Repeats the loop", "None of the above" }, 0),
                            new Question("Which of the following is used to create a new task in C#?", new string[] { "Task.Run()", "new Task()", "Task.Create()", "Task.Start()" }, 0),
                            new Question("What is an 'abstract' class in C#?", new string[] { "A class that cannot be instantiated", "A class with no implementation", "A class that implements interfaces", "A class with only static methods" }, 0),
                            new Question("What is the result of '5.5 / 2' in C#?", new string[] { "2.5", "3.0", "2", "3.5" }, 0),
                            new Question("What is a 'readonly' field in C#?", new string[] { "A field that can only be assigned once", "A field with a constant value", "A field that is mutable", "A field defined with the 'static' keyword" }, 0)
                        }},
                        { 3, new List<Question> {
                            new Question("What is the purpose of the 'async' keyword in C#?", new string[] { "Marks a method as asynchronous", "Marks a method as synchronous", "Marks a method as deprecated", "Marks a method as virtual" }, 0),
                            new Question("Which of the following is used for multi-threading in C#?", new string[] { "Thread", "Task", "BackgroundWorker", "All of the above" }, 3),
                            new Question("What is a 'Task' in C#?", new string[] { "A way to represent an asynchronous operation", "A collection", "A method", "None of the above" }, 0),
                            new Question("Which of the following methods is used to parse a string into an integer?", new string[] { "ParseInt()", "ToInt()", "Convert.ToInt32()", "Int.Parse()" }, 2),
                            new Question("What is the 'Thread.Sleep()' method used for in C#?", new string[] { "Pauses the execution of the current thread", "Creates a new thread", "Stops all threads", "None of the above" }, 0),
                            new Question("What is the result of '10 / 3' in C#?", new string[] { "3", "3.33", "3.0", "4" }, 0),
                            new Question("Which method is used to perform a case-insensitive comparison in C#?", new string[] { "Equals()", "Compare()", "StringCompare()", "String.Compare()" }, 3),
                            new Question("What does the 'default' keyword do in C#?", new string[] { "Returns the default value of a type", "Returns null", "Creates a new instance", "None of the above" }, 0),
                            new Question("What is the 'null-coalescing' operator in C#?", new string[] { "??", "&&", "||", "???" }, 0),
                            new Question("Which of the following is used to create a collection of key-value pairs?", new string[] { "Dictionary", "List", "Queue", "Array" }, 0),
                            new Question("Which method is used to raise an event in C#?", new string[] { "Raise()", "Invoke()", "Trigger()", "Fire()" }, 1),
                            new Question("What is the purpose of the 'lock' keyword in C#?", new string[] { "To synchronize access to a resource", "To create a loop", "To define a method", "To handle exceptions" }, 0),
                            new Question("What does the 'var' keyword represent in C#?", new string[] { "A dynamically typed variable", "A reference type", "A constant", "A value type" }, 0),
                            new Question("What is an 'interface' in C#?", new string[] { "A contract for classes", "A method", "A class type", "A collection" }, 0),
                            new Question("Which of the following methods is used to add an item to a collection in C#?", new string[] { "Add()", "Push()", "Insert()", "Append()" }, 0),
                            new Question("Which keyword is used to define a class in C#?", new string[] { "class", "def", "object", "type" }, 0),
                            new Question("What is the purpose of 'Dispose()' method in C#?", new string[] { "Releases resources used by an object", "Frees memory", "Deletes an object", "None of the above" }, 0),
                            new Question("What does the 'continue' statement do in a loop in C#?", new string[] { "Skips the current iteration and continues with the next one", "Exits the loop", "Repeats the loop", "None of the above" }, 0)
                        }},
                        { 4, new List<Question> {
                            new Question("What does the 'dynamic' keyword do in C#?", new string[] { "Declares a variable with runtime type resolution", "Declares a variable with a fixed type", "Declares a variable with static typing", "None of the above" }, 0),
                            new Question("What is the difference between 'string' and 'String' in C#?", new string[] { "They are the same", "string is an alias for String", "String is a class, and string is a primitive type", "string is used for numbers only" }, 1),
                            new Question("Which of the following is used to ensure that a method can be called only once?", new string[] { "seal", "onecall", "readonly", "Singleton" }, 3),
                            new Question("What is the purpose of the 'Task.WhenAll()' method in C#?", new string[] { "Waits for multiple tasks to complete", "Executes multiple tasks in parallel", "Waits for one task to complete", "Executes tasks sequentially" }, 0),
                            new Question("What does the 'await' keyword do in C#?", new string[] { "Suspends the execution of a method until the task completes", "Creates a new task", "Marks a method as asynchronous", "Executes a task in parallel" }, 0),
                            new Question("What is a 'value tuple' in C#?", new string[] { "A tuple that stores multiple data types", "A variable type used for simple data structures", "A type for handling complex data", "A special type of array" }, 1),
                            new Question("Which of the following collections allows duplicate elements in C#?", new string[] { "List", "Dictionary", "HashSet", "Queue" }, 0),
                            new Question("Which of the following operators is used for null conditional checking in C#?", new string[] { "??", "?.", "??=", "!" }, 1),
                            new Question("Which of the following methods can be used to serialize an object in C#?", new string[] { "Json.Serialize()", "BinaryFormatter.Serialize()", "Convert.Serialize()", "Write.Serialize()" }, 1),
                            new Question("What is the 'IEnumerable' interface used for in C#?", new string[] { "Represents a collection that can be enumerated", "Represents a list of objects", "Represents a type-safe collection", "None of the above" }, 0),
                            new Question("What is the purpose of the 'sealed' keyword in C#?", new string[] { "Prevents a class from being inherited", "Makes a class static", "Makes a class abstract", "Prevents method overriding" }, 0),
                            new Question("What is the output of the following C# code snippet: 'int x = 10; x++; Console.WriteLine(x);'?", new string[] { "10", "11", "12", "9" }, 1),
                            new Question("Which of the following is used to define a destructor in C#?", new string[] { "Finalize", "Destructor", "Dispose", "Destructor()" }, 0),
                            new Question("Which of the following collection types in C# is unordered and cannot contain duplicate elements?", new string[] { "HashSet", "List", "Queue", "Dictionary" }, 0),
                            new Question("What is the purpose of the 'LINQ' (Language Integrated Query) in C#?", new string[] { "Querying collections in a declarative manner", "Managing database connections", "Handling asynchronous operations", "Optimizing performance" }, 0),
                            new Question("What is the result of '5 + 5 * 5' in C#?", new string[] { "50", "30", "25", "10" }, 1),
                            new Question("Which method is used to check whether a string starts with a specific substring in C#?", new string[] { "StartsWith()", "BeginsWith()", "Contains()", "IndexOf()" }, 0),
                            new Question("What is the correct way to declare a nullable integer in C#?", new string[] { "int? x;", "nullable int x;", "int x = null;", "null int x;" }, 0),
                            new Question("Which of the following represents a method that can be called asynchronously in C#?", new string[] { "Task", "Action", "AsyncAction", "Thread" }, 0),
                            new Question("What does the 'break' statement do in a C# loop?", new string[] { "Exits the loop", "Skips the current iteration", "Pauses the loop", "None of the above" }, 0),
                            new Question("What is the purpose of the 'Dispose()' method in the IDisposable interface in C#?", new string[] { "Releases unmanaged resources", "Releases managed resources", "Finalizes a task", "Disposes of a thread" }, 0)
                        }}
                    }
            },
            {
                                "Python", new Dictionary<int, List<Question>> {
                        { 1, new List<Question> {
                            new Question("What is Python?", new string[] { "A snake", "A programming language", "A software framework", "None of the above" }, 1),
                            new Question("What does PEP stand for?", new string[] { "Python Enhancement Proposal", "Python Execution Path", "Python Executable Process", "None of the above" }, 0),
                            new Question("Which function is used to get the length of a list in Python?", new string[] { "len()", "length()", "size()", "count()" }, 0),
                            new Question("What is the correct way to define a function in Python?", new string[] { "def function():", "function():", "function define():", "None of the above" }, 0),
                            new Question("How do you create a variable in Python?", new string[] { "variable = value", "var value", "let value", "None of the above" }, 0),
                            new Question("What is the correct way to comment in Python?", new string[] { "# Comment", "// Comment", "/* Comment */", "<-- Comment -->" }, 0),
                            new Question("Which keyword is used to define a function in Python?", new string[] { "def", "function", "func", "define" }, 0),
                            new Question("Which of the following is a valid list in Python?", new string[] { "[1, 2, 3]", "(1, 2, 3)", "{1, 2, 3}", "None of the above" }, 0),
                            new Question("What is the output of print(5 * 'Python')?", new string[] { "PythonPythonPythonPythonPython", "Python", "5Python", "Python5" }, 0),
                            new Question("Which of the following is an immutable data type in Python?", new string[] { "String", "List", "Set", "Dictionary" }, 0),
                            new Question("Which of the following is the correct way to create a tuple in Python?", new string[] { "(1, 2, 3)", "[1, 2, 3]", "{1, 2, 3}", "None of the above" }, 0),
                            new Question("Which of the following is a mutable data type in Python?", new string[] { "List", "Tuple", "String", "Integer" }, 0),
                            new Question("What does the 'return' keyword do in Python?", new string[] { "Exits the function", "Returns a value from a function", "Starts a function", "None of the above" }, 1),
                            new Question("What is the result of 3 + 2 * 5 in Python?", new string[] { "25", "13", "16", "10" }, 1),
                            new Question("Which of the following operators is used for division in Python?", new string[] { "/", "//", "%", "*" }, 0),
                            new Question("How do you create an empty dictionary in Python?", new string[] { "{}", "[]", "()", "dict()" }, 3),
                            new Question("Which method is used to append an item to a list in Python?", new string[] { "append()", "add()", "push()", "insert()" }, 0),
                            new Question("What is the correct way to define a class in Python?", new string[] { "class MyClass:", "define class MyClass:", "class MyClass{}", "class MyClass()" }, 0)
                        }},
                        { 2, new List<Question> {
                            new Question("What is a tuple in Python?", new string[] { "A list", "An immutable list", "A function", "None of the above" }, 1),
                            new Question("What does the 'def' keyword do in Python?", new string[] { "Defines a function", "Defines a variable", "Defines a class", "Defines a loop" }, 0),
                            new Question("Which of the following is a mutable data type in Python?", new string[] { "List", "Tuple", "String", "Integer" }, 0),
                            new Question("What is the output of print(3 * 'Python')?", new string[] { "PythonPythonPython", "Python", "3Python", "Python3" }, 0),
                            new Question("What does the 'is' keyword do in Python?", new string[] { "Checks object identity", "Checks equality", "Checks type", "None of the above" }, 0),
                            new Question("What is the method used to append an item to a list in Python?", new string[] { "append()", "add()", "push()", "insert()" }, 0),
                            new Question("How do you create a new dictionary in Python?", new string[] { "{}", "[]", "()", "dict()" }, 0),
                            new Question("What does the 'continue' statement do in Python?", new string[] { "Skips the current iteration", "Ends the loop", "Restarts the loop", "None of the above" }, 0),
                            new Question("Which of the following is a correct way to handle an exception in Python?", new string[] { "try/except", "try/catch", "try/finally", "None of the above" }, 0),
                            new Question("Which of the following methods is used to remove an item from a list in Python?", new string[] { "remove()", "delete()", "pop()", "all of the above" }, 3),
                            new Question("Which method is used to check if a key exists in a dictionary in Python?", new string[] { "has_key()", "contains()", "keyexists()", "in" }, 3),
                            new Question("What is the default value of a boolean variable in Python?", new string[] { "True", "False", "None", "0" }, 1),
                            new Question("Which of the following is a valid set in Python?", new string[] { "{1, 2, 3}", "(1, 2, 3)", "[1, 2, 3]", "None of the above" }, 0),
                            new Question("How do you create an empty set in Python?", new string[] { "{}", "set()", "[]", "() " }, 1),
                            new Question("What is the result of 2 ** 3 in Python?", new string[] { "6", "8", "9", "7" }, 1),
                            new Question("Which operator is used to check equality in Python?", new string[] { "==", "=", "=", "===" }, 0),
                            new Question("What is the method used to remove duplicates from a list in Python?", new string[] { "set()", "unique()", "remove_duplicates()", "distinct()" }, 0),
                            new Question("What is the purpose of the 'lambda' keyword in Python?", new string[] { "To define anonymous functions", "To define a variable", "To create a class", "None of the above" }, 0)
                        }},
                        { 3, new List<Question> {
                            new Question("Which method is used to check if a key exists in a dictionary in Python?", new string[] { "has_key()", "contains()", "keyexists()", "in" }, 3),
                            new Question("What is the correct way to define a class in Python?", new string[] { "class MyClass:", "define class MyClass:", "class MyClass{}", "class MyClass()" }, 0),
                            new Question("What is the default value of a boolean variable in Python?", new string[] { "True", "False", "None", "0" }, 1),
                            new Question("Which of the following is a valid set in Python?", new string[] { "{1, 2, 3}", "(1, 2, 3)", "[1, 2, 3]", "None of the above" }, 0),
                            new Question("What is the method used to remove duplicates from a list in Python?", new string[] { "set()", "unique()", "remove_duplicates()", "distinct()" }, 0),
                            new Question("What is the result of 5 / 2 in Python 3?", new string[] { "2", "2.5", "3", "None of the above" }, 1),
                            new Question("What is the method used to convert a string to a number in Python?", new string[] { "to_int()", "int()", "convert()", "parse()" }, 1),
                            new Question("How do you create an empty set in Python?", new string[] { "{}", "set()", "[]", "() " }, 1),
                            new Question("Which operator is used for exponentiation in Python?", new string[] { "*", "^", "**", "//" }, 2),
                            new Question("Which module is used to work with dates and times in Python?", new string[] { "time", "datetime", "date", "calendar" }, 1),
                            new Question("What is the correct way to handle multiple exceptions in Python?", new string[] { "except (Exception1, Exception2):", "except Exception1, Exception2:", "except Exception1 as e1, Exception2 as e2:", "None of the above" }, 0),
                            new Question("What does the 'yield' keyword do in Python?", new string[] { "Returns a value from a generator", "Stops a loop", "Pauses function execution", "None of the above" }, 0),
                            new Question("What is the method used to join elements of a list in Python?", new string[] { "join()", "concatenate()", "combine()", "append()" }, 0),
                            new Question("Which of the following is an immutable data type in Python?", new string[] { "List", "String", "Set", "Dictionary" }, 1),
                            new Question("What does the 'in' operator do in Python?", new string[] { "Checks if an item exists in a collection", "Checks if two objects are equal", "Compares two variables", "None of the above" }, 0),
                            new Question("How do you delete an item from a dictionary in Python?", new string[] { "del dictionary[key]", "dictionary.remove(key)", "dictionary.pop(key)", "All of the above" }, 3),
                            new Question("What is the result of 10 // 3 in Python?", new string[] { "3", "3.0", "2", "4" }, 0),
                            new Question("How do you create an empty dictionary in Python?", new string[] { "{}", "[]", "()", "dict()" }, 3)
                        }},
                        { 4, new List<Question> {
                            new Question("What is the method used to check if a key exists in a dictionary in Python?", new string[] { "has_key()", "contains()", "keyexists()", "in" }, 3),
                            new Question("What is the correct way to define a class in Python?", new string[] { "class MyClass:", "define class MyClass:", "class MyClass{}", "class MyClass()" }, 0),
                            new Question("What is the default value of a boolean variable in Python?", new string[] { "True", "False", "None", "0" }, 1),
                            new Question("Which of the following is a valid set in Python?", new string[] { "{1, 2, 3}", "(1, 2, 3)", "[1, 2, 3]", "None of the above" }, 0),
                            new Question("What is the method used to remove duplicates from a list in Python?", new string[] { "set()", "unique()", "remove_duplicates()", "distinct()" }, 0),
                            new Question("What is the result of 5 / 2 in Python 3?", new string[] { "2", "2.5", "3", "None of the above" }, 1),
                            new Question("What is the method used to convert a string to a number in Python?", new string[] { "to_int()", "int()", "convert()", "parse()" }, 1),
                            new Question("How do you create an empty set in Python?", new string[] { "{}", "set()", "[]", "() " }, 1),
                            new Question("Which operator is used for exponentiation in Python?", new string[] { "*", "^", "**", "//" }, 2),
                            new Question("Which module is used to work with dates and times in Python?", new string[] { "time", "datetime", "date", "calendar" }, 1),
                            new Question("What is the correct way to handle multiple exceptions in Python?", new string[] { "except (Exception1, Exception2):", "except Exception1, Exception2:", "except Exception1 as e1, Exception2 as e2:", "None of the above" }, 0),
                            new Question("What does the 'yield' keyword do in Python?", new string[] { "Returns a value from a generator", "Stops a loop", "Pauses function execution", "None of the above" }, 0),
                            new Question("What is the method used to join elements of a list in Python?", new string[] { "join()", "concatenate()", "combine()", "append()" }, 0),
                            new Question("Which of the following is an immutable data type in Python?", new string[] { "List", "String", "Set", "Dictionary" }, 1),
                            new Question("What does the 'in' operator do in Python?", new string[] { "Checks if an item exists in a collection", "Checks if two objects are equal", "Compares two variables", "None of the above" }, 0),
                            new Question("How do you delete an item from a dictionary in Python?", new string[] { "del dictionary[key]", "dictionary.remove(key)", "dictionary.pop(key)", "All of the above" }, 3),
                            new Question("What is the result of 10 // 3 in Python?", new string[] { "3", "3.0", "2", "4" }, 0),
                            new Question("How do you create an empty dictionary in Python?", new string[] { "{}", "[]", "()", "dict()" }, 3)
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

    public Question(string questionText, string[] possibleAnswers, int correctAnswerIndex)
    {
        this.questionText = questionText;
        this.possibleAnswers = possibleAnswers;
        this.correctAnswerIndex = correctAnswerIndex;
    }
}
