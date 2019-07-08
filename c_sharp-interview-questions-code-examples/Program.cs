using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_interview_questions_code_examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# interview questions - code examples\n");
            QuestionsFromGuru99.Question3();
            QuestionsFromGuru99.Question7();

            Console.WriteLine("\nEnd of interview questions - code examples");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// URL: https://www.guru99.com/c-sharp-interview-questions.html
    /// </summary>
    public static class QuestionsFromGuru99
    {
        /// <summary>
        /// 3. Can multiple catch blocks be executed?
        /// </summary>
        /// <answer>
        /// No, Multiple catch blocks can't be executed. Once the proper catch code executed, 
        /// the control is transferred to the finally block and then the code that follows the finally block gets executed.
        /// </answer>
        public static void Question3()
        {
            try
            {
                throw new ArgumentNullException();
                //ArgumentNullException -> ArgumentException -> SystemException -> Exception
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("In catch ArgumentNullException block");
                //Here catch block with ArgumentNullException needs to be before catch block with Exception - 
                //Compiler thows error that Exception block (if it is first will catch all exceptions logged)
            }
            catch (Exception)
            {
                Console.WriteLine("In catch Exception block");
            }
            finally
            {
                Console.WriteLine("In finally block");
            }
        }


        /// <summary>
        /// 7. What is Jagged Arrays?
        /// </summary>
        /// <answer>
        /// The array which has elements of type array is called jagged array. 
        /// The elements can be of different dimensions and sizes. 
        /// We can also call jagged array as Array of arrays.
        /// </answer>
        /// <more>
        /// https://www.c-sharpcorner.com/UploadFile/puranindia/jagged-arrays-in-C-Sharp-net/
        /// </more>
        public static void Question7()
        {
            int[][] jaggedArray = new int[2][];
            jaggedArray[0] = new int[] { 2, 3, 4, 5 };
            jaggedArray[1] = new int[] { 1, 10 };

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine($"elem {i} of array in jaggedArray lenght: {jaggedArray[i].Length}");
            }
        }
        /// <summary>
        /// 8. What is the difference between ref & out parameters?
        /// </summary>
        /// <answer>
        /// An argument passed as ref must be initialized before passing to the method whereas out parameter needs not to be initialized before passing to a method.
        /// </answer>
        public static void Question8()
        {
            //call SampleMethod1 - with out int:
            Question8_SampleMethod1(out int myOutInt);

            // now need to create instance of another int to pass it to SampleMethod2
            int myRefInt = 2; // it need to be initialized - Declaring variable is not enough (int myRefInt - will not work)
            Question8_SampleMethod2(ref myRefInt);
        }

        private static void Question8_SampleMethod1(out int outInt)
        {
            outInt = 21;
        }
        private static void Question8_SampleMethod2(ref int refInt)
        {
            refInt = 93;
        }

        /// <summary>
        /// 10. What is serialization?
        /// </summary>
        /// <answer>
        /// The process of converting an object into a stream of bytes is called Serialization
        /// </answer>
        public static void Question10()
        {
            var classToSerialize = new SerializableClass()
            {
                myInt = 12,
                myString = "Hello project"
            };
        }

        /// <summary>
        /// 11. Can "this" be used within a static method?
        /// </summary>
        /// <answer>
        /// We can't use 'This' in a static method because we can only use static variables/methods in a static method.
        /// </answer>
        public static void Question11()
        {
            //this.  // not allowed
            // follow up in SerializableClass -> GetObjectData 
        }
    }

    public class SerializableClass : ISerializable
    {
        private float myPrivateFloat;
        public int myInt;
        public string myString { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("myPrivateFloat", myPrivateFloat, typeof(float));
            info.AddValue("myInt", myInt);
            info.AddValue("myString", myInt);

            // follow up to Qyuestion 11:
            this.myPrivateFloat = 1; // works
        }
    }

}
