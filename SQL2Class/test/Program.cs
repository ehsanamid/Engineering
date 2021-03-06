﻿using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
using System.Reflection;
using System.Text;
//using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a compile unit
            CodeCompileUnit compileUnit = new CodeCompileUnit();

            // Define a Namespace
            //CodeNamespace automobileNamespace = new CodeNamespace("Automobile");
            CodeNamespace automobileNamespace1 = new CodeNamespace();
            // Import Namespaces
            automobileNamespace1.Imports.Add(new CodeNamespaceImport("System"));

            compileUnit.Namespaces.Add(automobileNamespace1);
            CodeNamespace automobileNamespace = new CodeNamespace("Automobile");
            compileUnit.Namespaces.Add(automobileNamespace);
            // Define a class
            CodeTypeDeclaration focusClass = new CodeTypeDeclaration("Focus");
            // Inherit a type
            focusClass.BaseTypes.Add("Car");

            automobileNamespace.Types.Add(focusClass);


            // Set custom attribute
            CodeAttributeDeclaration codeAttribute = new CodeAttributeDeclaration("System.Serializable");
            focusClass.CustomAttributes.Add(codeAttribute);
            // Set class attribute
            focusClass.IsClass = true;
            focusClass.TypeAttributes = TypeAttributes.Public;

            // Declare a class member field
            CodeMemberField speedField = new CodeMemberField();
            speedField.Attributes = MemberAttributes.Private;
            speedField.Name = "_Speed";
            speedField.Type = new CodeTypeReference(typeof(int));

            focusClass.Members.Add(speedField);


            // Define a property
            CodeMemberProperty speedProperty = new CodeMemberProperty();
            speedProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            speedProperty.Name = "Speed";
            speedProperty.HasGet = true;
            speedProperty.Type = new CodeTypeReference(typeof(int));

            speedProperty.GetStatements.Add(new CodeMethodReturnStatement(
                new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_Speed")));

            focusClass.Members.Add(speedProperty);


            // Declare a method
            CodeMemberMethod accelerateMethod = new CodeMemberMethod();
            accelerateMethod.Attributes = MemberAttributes.Public;
            accelerateMethod.Name = "Accelerate";

            CodeFieldReferenceExpression speedFieldReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_Speed");

            CodeBinaryOperatorExpression addExpression = new CodeBinaryOperatorExpression(
                speedFieldReference, CodeBinaryOperatorType.Add, new CodePrimitiveExpression(10));

            CodeAssignStatement assignStatement = new CodeAssignStatement(speedFieldReference, addExpression);

            accelerateMethod.Statements.Add(assignStatement);
            focusClass.Members.Add(accelerateMethod);


            

            


            // Declare the constructor
            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            // Add a parameter
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(int), "speed"));
            // Add field initialization logic
            constructor.Statements.Add(new CodeAssignStatement(speedFieldReference, new CodeArgumentReferenceExpression("speed")));

            focusClass.Members.Add(constructor);


            // Define the entry point
            CodeEntryPointMethod entryPointMethod = new CodeEntryPointMethod();
            CodeObjectCreateExpression focusObjectCreate = new CodeObjectCreateExpression(
                new CodeTypeReference("Focus"), new CodePrimitiveExpression(0));
            // Add the statement: "Focus focus = new Focus(0);"
            entryPointMethod.Statements.Add(new CodeVariableDeclarationStatement(
                new CodeTypeReference("Focus"), "focus", focusObjectCreate));
            // Create the expression: "focus.Accelerate()"
            CodeMethodInvokeExpression accelerateInvoke = new CodeMethodInvokeExpression(
                new CodeVariableReferenceExpression("focus"), "Accelerate");

            entryPointMethod.Statements.Add(accelerateInvoke);
            focusClass.Members.Add(entryPointMethod);

            // Generate C# source code
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            using (StreamWriter sourceWriter = new StreamWriter("D:\\DSC.dev\\Source-VS11\\SQL2Class\\SQL2Class\\test\\Focus.cs"))
            {
                provider.GenerateCodeFromCompileUnit(compileUnit, sourceWriter, options);
            }
        }
    }
}
