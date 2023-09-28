using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public static class Single
    {
        //Coding Exercise 1
        /*
         Implement the GetTheOnlyUpperCaseWord method, which given a collection 
         of strings:
            *will return the only upper case string, if only one is present
            *will return null if no upper case string is present
            *will throw an InvalidOperationException if two or more upper case 
               strings are present.
         For example:
            *for words {"aaa", "BBB", "CcC"} the result will be "BBB"
            *for words {"aaa", "bbB", "CcC"} the result will be null
            *for words {"aaa", "BBB", "CcC", "DDD"} InvalidOperationException 
                will be thrown
         */
        public static string GetTheOnlyUpperCaseWord(IEnumerable<string> words)
        {
            return words.SingleOrDefault(w => w.All(c => Char.IsUpper(c)));
        }

        /*
        Implement the GetSingleElementCollection method, which given a nested collection
        of integers will return the only collection which contains only a single element. 
        
        For example, for numberCollections parameter like this:
            *numberCollections[0] = {1,2,3}
            *numberCollections[1] = {4}
            *numberCollections[2] = {5,6}
        ...the result shall be numberCollections[1], because it is the only 
        single-element collection in the input parameter

        If there is no single-element list present, or there is more than one list 
        like that, an InvalidOperationException should be thrown.

        For example, for numberCollections parameter like this:
            *numberCollections[0] = {1,2,3}
            *numberCollections[1] = {5,6}
        ...InvalidOperationException should be thrown, 
        because there is no single-element collection here.

        For example, for numberCollections parameter like this:
            *numberCollections[0] = {1,2,3}
            *numberCollections[1] = {4}
            *numberCollections[2] = {5,6}
            *numberCollections[3] = {7}

        ...InvalidOperationException should be thrown, 
        because there are two single-element collections here.
         */
        //Coding Exercise 2
        public static IEnumerable<int> GetSingleElementCollection(
            IEnumerable<IEnumerable<int>> numberCollections)
        {
            return numberCollections.Single(coll => coll.Count() == 1);

        }

        //Refactoring challenge
        public static DateTime? GetSingleDay_Refactored(
            IEnumerable<DateTime> dates, DayOfWeek dayOfWeek)
        {

            // I came up with this clunky solution partly because I had overlooked that
            // the original method only returned a date if there was only one matching date;
            // I was thinking we had to return the first match even if there were more.
            // But I was also mistaken in how this works - in the case of an exception thrown,
            // result does not get written to. Thus, the below does meet the spec
            // but not by my design!

            //DateTime? result = null;

            //try{ 
            //    result = dates.SingleOrDefault(d => d.DayOfWeek == dayOfWeek); 
            //}
            //catch (Exception ex)
            //{
            //    // Ignore exception on additional match
            //}

            //return result == DateTime.MinValue ? null : result;

            // This solution is much better! First we get the count of matching days.
            // It should be noted though that SingleOrDefault would also work here,
            //  as we're not going to get an exception from it for additional days
            return dates.Count(d => d.DayOfWeek == dayOfWeek) == 1 ?
                dates.Single(d => d.DayOfWeek == dayOfWeek) :
                (DateTime?)null;

        }

        //do not modify this method
        public static DateTime? GetSingleDay(
            IEnumerable<DateTime> dates, DayOfWeek dayOfWeek)
        {
            var count = 0;
            DateTime? result = null;
            foreach (var date in dates)
            {
                if (date.DayOfWeek == dayOfWeek)
                {
                    result = date;
                    count++;
                }
            }
            if (count == 1)
            {
                return result;
            }
            return null;
        }

        public enum PetType
        {
            Cat,
            Dog,
            Fish
        }

        public class Pet
        {
            public int Id { get; }
            public string Name { get; }
            public PetType PetType { get; }
            public float Weight { get; }

            public Pet(int id, string name, PetType petType, float weight)
            {
                Id = id;
                Name = name;
                PetType = petType;
                Weight = weight;
            }

            public override string ToString()
            {
                return $"Id: {Id}, Name: {Name}, Type: {PetType}, Weight: {Weight}";
            }
        }
    }
}
