using System;
using System.Linq;

namespace WPFTypeApp.View;

public class TextGenerator
{
    private static readonly string[] Words = {
    "algorithm", "array", "boolean", "class", "compile", "constructor", "debug",
    "decompile", "encapsulation", "exception", "float", "function", "inheritance",
    "integer", "interface", "iteration", "loop", "method", "object", "parameter",
    "polymorphism", "recursion", "string", "variable", "abstract", "asynchronous",
    "binary", "byte", "callback", "char", "conditional", "constant", "data",
    "datatype", "declaration", "delegate", "dependency", "development", "directive",
    "double", "enumeration", "framework", "generic", "identifier", "implementation",
    "library", "logic", "member", "memory", "operator", "overload", "pointer",
    "procedure", "prototype", "query", "queue", "reference", "repository", "runtime",
    "syntax", "thread", "token", "type", "value", "virtual", "void", "widget",
    "workflow", "API", "architecture", "argument", "assertion", "build", "bytecode",
    "client", "closure", "cluster", "code", "compile-time", "component", "compression",
    "concurrency", "container", "debugger", "decryption", "deployment", "design",
    "diagram", "encryption", "endpoint", "entity", "environment", "exception handling",
    "expression", "file", "filter", "framework", "frontend", "functionality", "heap",
    "inherit", "input", "instance", "integration", "key", "layer", "library", "logic",
    "loop", "memory management", "module", "network", "object-oriented", "optimize",
    "package", "parameter", "pattern", "performance", "platform", "plugin", "pointer",
    "procedure", "process", "protocol", "proxy", "query", "queue", "recursion",
    "refactor", "regex", "repository", "runtime", "script", "SDK", "security",
    "server", "socket", "software", "source code", "stack", "statement", "string",
    "structure", "syntax", "system", "tag", "test", "thread", "token", "UI",
    "unicode", "unit testing", "user interface", "validation", "variable", "version",
    "virtual machine", "web", "widget", "workflow", "XML", "abstract", "assert", "boolean",
    "break", "byte", "case", "catch", "char",
    "class", "const", "continue", "default", "do", "double", "else", "enum",
    "extends", "final", "finally", "float", "for", "goto", "if", "implements",
    "import", "instanceof", "int", "interface", "long", "native", "new", "null",
    "package", "private", "protected", "public", "return", "short", "static",
    "strictfp", "super", "switch", "synchronized", "this", "throw", "throws",
    "transient", "try", "void", "volatile", "while", "true", "false", "var",
    "function", "let", "const", "console", "log", "typeof", "delete", "yield",
    "await", "async", "from", "of", "in", "out", "get", "set", "lambda", "action",
    "list", "map", "filter", "reduce", "foreach", "using", "namespace", "public",
    "private", "protected", "internal", "static", "async", "await", "exception",
    "try", "catch", "finally", "throw", "throws", "nullable", "override", "virtual",
    "abstract", "interface", "sealed", "delegate", "event", "extern", "volatile",
    "fixed", "operator", "params", "readonly", "ref", "out", "sizeof", "stackalloc",
    "struct", "switch", "unsafe", "fixed", "lock", "object", "string", "boolean",
    "byte", "sbyte", "char", "decimal", "double", "float", "int", "uint", "long",
    "ulong", "short", "ushort", "void", "checked", "unchecked"
};


    public static string GenerateRandomText(int wordCount)
    {
        Random rnd = new Random();
        return string.Join(" ", Enumerable.Range(0, wordCount).Select(i => Words[rnd.Next(Words.Length)]));
    }
}